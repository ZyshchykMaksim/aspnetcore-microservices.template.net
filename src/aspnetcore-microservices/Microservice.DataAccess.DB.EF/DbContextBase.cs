﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Microservice.DataAccess.DB.EF
{
    public class DbContextBase : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextBase"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public DbContextBase([NotNull] DbContextOptions options) : base(options)
        {

        }

        #region Overrides of DbContext

        /// <inheritdoc cref="DbContext"/>
        public override int SaveChanges()
        {
            AuditEntries();
            SoftDeleteEntries();

            return base.SaveChanges();
        }

        /// <inheritdoc cref="DbContext"/>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AuditEntries();
            SoftDeleteEntries();

            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Adds information about audit entries.
        /// </summary>
        private void AuditEntries()
        {
            var modifiedSourceInfo = ChangeTracker.Entries<IAuditable>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (EntityEntry<IAuditable> entry in modifiedSourceInfo)
            {
                if (entry.State == EntityState.Added && (DateTime)entry.Property("CreatedUtc").CurrentValue == DateTime.MinValue)
                {
                    entry.Property("CreatedBy").CurrentValue = string.Empty;
                    entry.Property("CreatedUtc").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedBy").CurrentValue = string.Empty;
                    entry.Property("UpdatedUtc").CurrentValue = DateTime.UtcNow;
                }
            }
        }

        /// <summary>
        ///  Adds information about soft delete entries.
        /// </summary>
        private void SoftDeleteEntries()
        {
            var modifiedSourceInfo = ChangeTracker.Entries<ISoftDelitable>()
                .Where(e => e.State == EntityState.Deleted);

            foreach (EntityEntry<ISoftDelitable> entry in modifiedSourceInfo)
            {
                entry.State = EntityState.Modified;
                entry.Property("DeletedBy").CurrentValue = string.Empty;
                entry.Property("DeletedUtc").CurrentValue = DateTime.UtcNow;
            }
        }

        #endregion
    }
}