using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microservice.Entities.MongoDb;

namespace Microservice.DataAccess.DB.Mongo
{
    /// <summary>
    /// The repository for communication with the data source.
    /// </summary>
    public interface IRepository<TKey, TDocument> where TDocument : IDocument<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Finds entitis according to predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public IReadOnlyList<TDocument> Find(Expression<Func<TDocument, bool>> predicate);

        /// <summary>
        /// Adds an new entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        void Add(TDocument entity);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AddRange(IEnumerable<TDocument> entities);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        void Update(TDocument entity);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        void Remove(TDocument entity);

        /// <summary>
        /// Removes the specified range of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void RemoveRange(IEnumerable<TDocument> entities);
    }
}
