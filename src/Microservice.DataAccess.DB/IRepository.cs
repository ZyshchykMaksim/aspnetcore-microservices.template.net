using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microservice.Domain.Entities;

namespace Microservice.DataAccess.DB
{
    /// <summary>
    /// The repository for communication with the data source.
    /// </summary>
    /// <typeparam name="T">The type of entity. </typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Gets the information about entities.
        /// </summary>
        /// <param name="predicate">The predicate to search.</param>
        /// <param name="orderBy">The conditions for ordering.</param>
        /// <param name="includes">The conditions to include tables.</param>
        /// <param name="disableTracking">The flag that indicates whether to enable tracking of changes.</param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate = null,
            List<Expression<Func<T, object>>> includes = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool disableTracking = true);

        /// <summary>
        /// Adds an new entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <param name="updateWholeEntity">if set to <c>true</c> updates whole entity otherwise updates only modified fields.</param>
        /// <param name="rowVersion">The row version.</param>
        /// <returns></returns>
        Task UpdateAsync(T entity, bool updateWholeEntity = false, byte[] rowVersion = null);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        Task RemoveAsync(T entity);

        /// <summary>
        /// Removes the specified range of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
