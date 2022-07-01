using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Microservice.DataAccess.DB.Dynamo.Entities;

namespace Microservice.DataAccess.DB.Dynamo
{
    /// <summary>
    /// The repository for communication with the data source.
    /// </summary>
    public interface IRepository<TKey, TEntity> where TEntity : IEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets item by unique identifier.
        /// </summary>
        /// <typeparam name="TEntity">Type to populate.</typeparam>
        /// <returns>Item if found, otherwise null.</returns>
        Task<TEntity> GetAsync(TKey key);

        /// <summary>
        /// Finds items that match the unique identifier.
        /// </summary>
        /// <param name="key"> The key element of the target item (partition key).</param>
        /// <param name="config">The config object with query conditions.</param>
        /// <returns></returns>
        Task<ICollection<TEntity>> QueryAsync(TKey key, DynamoDBOperationConfig config);

        /// <summary>
        /// Gets list of items by unique identifier.
        /// </summary>
        /// <param name="key">Hash key element of the target item (partition key).</param>
        /// <returns>Item if found, otherwise null.</returns>
        Task<IEnumerable<TEntity>> GetListAsync(TKey key);

        /// <summary>
        /// Gets item by unique identifier.
        /// </summary>
        /// <param name="key">The key element of the target item (partition key).</param>
        /// <param name="rangeKey">The range key element of the target item (sort key).</param>
        /// <returns>Item if found, otherwise null.</returns>
        Task<TEntity> GetAsync(TKey key, TKey rangeKey);

        /// <summary>
        /// Removes item by unique identifier.
        /// </summary>
        /// <param name="key">The key element of the target item (partition key).</param>
        /// <returns></returns>
        Task DeleteAsync(TKey key);

        /// <summary>
        /// Removes item by specified key.
        /// </summary>
        /// <param name="key">The key element of the target item (partition key).</param>
        /// <param name="rangeKey">The range key element of the target item (sort key).</param>
        /// <returns></returns>
        Task DeleteAsync(TKey key, TKey rangeKey);

        /// <summary>
        /// Adds a new item or updates existing one.
        /// </summary>
        /// <param name="item">Object to save.</param>
        /// <returns></returns>
        Task AddOrUpdateAsync(TEntity item);

        /// <summary>
        /// Adds multiple items.
        /// </summary>
        /// <param name="items">The collection of item.</param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<TEntity> items);

        /// <summary>
        /// Removes multiple items.
        /// </summary>
        /// <param name="items">The collection of item.</param>
        /// <returns></returns>
        Task RemoveRangeAsync(IEnumerable<TEntity> items);
    }
}
