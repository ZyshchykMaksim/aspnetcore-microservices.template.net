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
        /// Gets the information about entity.
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
        /// Gets entity by unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Adds an new entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">The an new entity.</param>
        /// <returns></returns>
        Task DeleteAsync(T entity);
    }
}
