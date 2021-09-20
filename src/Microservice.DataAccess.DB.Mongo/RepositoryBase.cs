using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Microservice.Entities.MongoDb;
using MongoDB.Driver;

namespace Microservice.DataAccess.DB.Mongo
{
    public class RepositoryBase<TKey, TDocument> : IRepository<TKey, TDocument> where TDocument : IDocument<TKey> where TKey : IEquatable<TKey>
    {
        private readonly DbContextBase _dbContext;
        private readonly IMongoCollection<TDocument> _dbCollection;

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

            _dbCollection = dbContext.Database.GetCollection<TDocument>(tableName);
        }

        #region Implementation of IRepository<T>

        /// <inheritdoc />
        public IReadOnlyList<TDocument> Find(Expression<Func<TDocument, bool>> predicate)
        {
            return _dbCollection.Find(predicate).ToList();
        }

        /// <inheritdoc />
        public void Add(TDocument entity)
        {
            _dbCollection.InsertOne(entity);
        }

        /// <inheritdoc />
        public void AddRange(IEnumerable<TDocument> entities)
        {
            _dbCollection.InsertMany(entities);
        }

        /// <inheritdoc />
        public void Update(TDocument entity)
        {
            _dbCollection.ReplaceOne(Builders<TDocument>.Filter.Eq("_id", entity.Id), entity);
        }

        /// <inheritdoc />
        public void Remove(TDocument entity)
        {
            _dbCollection.DeleteOne(Builders<TDocument>.Filter.Eq("_id", entity.Id));
        }

        /// <inheritdoc />
        public void RemoveRange(IEnumerable<TDocument> entities)
        {
            var entitiesList = entities.ToList();

            if (!entitiesList.Any())
            {
                return;
            }

            var ids = entitiesList.Select(d => d.Id);

            _dbCollection.DeleteMany(Builders<TDocument>.Filter.In("_id", ids));
        }

        #endregion

        #region Private methods 

        /// <summary>
        /// Gets name table from entity.
        /// </summary>
        /// <returns></returns>
        private string GetCollectionName()
        {
            return (typeof(TDocument).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute)?.Name;
        }

        #endregion
    }
}
