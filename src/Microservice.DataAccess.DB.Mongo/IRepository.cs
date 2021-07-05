using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microservice.Domain;

namespace Microservice.DataAccess.DB.Mongo
{
    /// <summary>
    /// The repository for communication with the data source.
    /// </summary>
    /// <typeparam name="TEntity ">The type of entity. </typeparam>
    /// <typeparam name="TKey">The type of PK.</typeparam>
    public interface IRepository<TKey, TEntity> where TEntity : Intity<TKey>
    {
        /// <summary>
        /// Finds entitis according to predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public IReadOnlyList<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adds an new entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        void Add(TEntity entity);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        void Update(TEntity entity);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes the specified range of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
