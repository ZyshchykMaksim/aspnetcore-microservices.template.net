using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microservice.Domain;
using MongoDB.Driver;


namespace Microservice.DataAccess.DB.Mongo
{
    public class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        private readonly DbContextBase _dbContext;
        private readonly IMongoCollection<TEntity> _dbCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        public RepositoryBase(DbContextBase dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            var tableName = GetCollectionName();

            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new DataException("The table name is not defined. INSTRUCTIONS: Use the Table attribute for entity.");
            }

            _dbCollection = dbContext.Database.GetCollection<TEntity>(tableName);
        }

        #region Implementation of IRepository<T>

        /// <inheritdoc />
        public IReadOnlyList<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbCollection.Find(predicate).ToList();
        }

        /// <inheritdoc />
        public void Add(TEntity entity)
        {
            _dbCollection.InsertOne(entity);
        }

        /// <inheritdoc />
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbCollection.InsertMany(entities);
        }

        /// <inheritdoc />
        public void Update(TEntity entity)
        {
            _dbCollection.ReplaceOne(Builders<TEntity>.Filter.Eq("_id", entity.Id), entity);
        }

        /// <inheritdoc />
        public void Remove(TEntity entity)
        {
            _dbCollection.DeleteOne(Builders<TEntity>.Filter.Eq("_id", entity.Id));
        }

        /// <inheritdoc />
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            var entitiesList = entities.ToList();

            if (!entitiesList.Any())
            {
                return;
            }

            var ids = entitiesList.Select(d => d.Id);

            _dbCollection.DeleteMany(Builders<TEntity>.Filter.In("_id", ids));
        }

        #endregion

        #region Private methods 

        /// <summary>
        /// Gets name table from entity.
        /// </summary>
        /// <returns></returns>
        private string GetCollectionName()
        {
            return (typeof(TEntity).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute)?.Name;
        }

        #endregion
    }
}
