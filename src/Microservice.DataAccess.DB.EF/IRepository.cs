using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microservice.Entities.MSSQL;

namespace Microservice.DataAccess.DB.MSSQL
{
    /// <summary>
    /// The repository for communication with the data source.
    /// </summary>
    /// <typeparam name="TEntity ">The type of entity. </typeparam>
    /// <typeparam name="TKey">The type of PK.</typeparam>
    public interface IRepository<TKey, TEntity> where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// Gets the information about entities.
        /// </summary>
        /// <param name="predicate">The predicate to search.</param>
        /// <param name="orderBy">The conditions for ordering.</param>
        /// <param name="includes">The conditions to include tables.</param>
        /// <param name="disableTracking">The flag that indicates whether to enable tracking of changes.</param>
        /// <returns></returns>
        Task<IReadOnlyList<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            bool disableTracking = true);

        /// <summary>
        /// Adds an new entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <param name="updateWholeEntity">if set to <c>true</c> updates whole entity otherwise updates only modified fields.</param>
        /// <param name="rowVersion">The row version.</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity, bool updateWholeEntity = false, byte[] rowVersion = null);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        Task RemoveAsync(TEntity entity);

        /// <summary>
        /// Removes the specified range of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
