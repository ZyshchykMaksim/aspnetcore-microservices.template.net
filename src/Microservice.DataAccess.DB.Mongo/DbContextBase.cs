using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Domain;
using MongoFramework;
using MongoFramework.Infrastructure;

namespace Microservice.DataAccess.DB.Mongo
{
    public class DbContextBase : MongoDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextBase"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public DbContextBase([NotNull] IMongoDbConnection options) : base(options) { }

        #region Overrides of MongoDbContext

        public override void SaveChanges()
        {
            AuditEntries();

            base.SaveChanges();
        }

        public override Task SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AuditEntries();

            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion


        #region Private methods

        /// <summary>
        /// Adds information about audit entries.
        /// </summary>
        private void AuditEntries()
        {
            var modifiedSourceInfo = ChangeTracker
                .Entries()
                .Where(e => typeof(IAuditable).IsAssignableFrom(e.EntityType) && (e.State == EntityEntryState.Added || e.State == EntityEntryState.Updated));

            foreach (EntityEntry entry in modifiedSourceInfo)
            {
                var v1 = entry.Entity.GetType().GetProperty(nameof(IAuditable.CreatedUtc))?.GetValue(entry.Entity, null);

                if (entry.State == EntityEntryState.Added && v1 is DateTime value)
                {
                    if (value == DateTime.MinValue)
                    {
                        entry.Entity.GetType().GetProperty(nameof(IAuditable.CreatedBy))?.SetValue(entry.Entity, String.Empty, null);
                        entry.Entity.GetType().GetProperty(nameof(IAuditable.CreatedUtc))?.SetValue(entry.Entity, DateTime.UtcNow, null);
                    }
                }

                if (entry.State == EntityEntryState.Added || entry.State == EntityEntryState.Updated)
                {
                    entry.Entity.GetType().GetProperty(nameof(IAuditable.LastModifiedBy))?.SetValue(entry.Entity, String.Empty, null);
                    entry.Entity.GetType().GetProperty(nameof(IAuditable.LastModifiedUtc))?.SetValue(entry.Entity, DateTime.UtcNow, null);
                }
            }
        }


        /* NOTE: Method not used because found the bag in MongoFramework library.
         * Method ChangeTracker.SetEntityState(entry.Entity, EntityEntryState.Updated); does not change state from EntityEntryState.Deleted to EntityEntryState.Updated and creates a new EntityEntryState.Updated state in the collection of entity of state.
           
        /// <summary>
        ///  Adds information about soft delete entries.
        /// </summary>
        private void SoftDeleteEntries()
        {
           var modifiedSourceInfo = ChangeTracker
           .Entries()
           .Where(e => typeof(ISoftDelitable).IsAssignableFrom(e.EntityType) && e.State == EntityEntryState.Deleted)
           .ToList();
           
           foreach (var entry in modifiedSourceInfo)
           {
               ChangeTracker.SetEntityState(entry.Entity, EntityEntryState.Updated);
               entry.Entity.GetType().GetProperty(nameof(ISoftDelitable.DeletedBy))?.SetValue(entry.Entity, String.Empty, null);
               entry.Entity.GetType().GetProperty(nameof(ISoftDelitable.DeletedUtc))?.SetValue(entry.Entity, DateTime.UtcNow, null);
           }
        }
        */

        #endregion
    }
}
