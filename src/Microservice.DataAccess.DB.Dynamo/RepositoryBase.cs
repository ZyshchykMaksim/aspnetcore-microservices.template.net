using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Microservice.DataAccess.DB.Dynamo.Entities;

namespace Microservice.DataAccess.DB.Dynamo
{
    public class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : IEntity<TKey> where TKey : IEquatable<TKey>
    {
        private readonly IDynamoDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        public RepositoryBase(IDynamoDBContext context)
        {
            _context = context;
        }

        #region Implementation of IRepository<TKey,TEntity>

        /// <inheritdoc />.
        public async Task<TEntity> GetAsync(TKey key)
        {
            return await _context.LoadAsync<TEntity>(key);
        }

        /// <inheritdoc />.
        public async Task<ICollection<TEntity>> QueryAsync(TKey key, DynamoDBOperationConfig config)
        {
            var query = _context.QueryAsync<TEntity>(key, config);

            return await query.GetRemainingAsync();
        }

        /// <inheritdoc />.
        public async Task<IEnumerable<TEntity>> GetListAsync(TKey key)
        {
            var query = _context.QueryAsync<TEntity>(key);

            return await query.GetRemainingAsync();
        }

        /// <inheritdoc />.
        public async Task<TEntity> GetAsync(TKey key, TKey rangeKey)
        {
            return await _context.LoadAsync<TEntity>(key, rangeKey);
        }

        /// <inheritdoc />.
        public async Task DeleteAsync(TKey key)
        {
            await _context.DeleteAsync<TEntity>(key);
        }

        /// <inheritdoc />.
        public async Task DeleteAsync(TKey key, TKey rangeKey)
        {
            await _context.DeleteAsync<TEntity>(key, rangeKey);
        }

        /// <inheritdoc />.
        public async Task AddOrUpdateAsync(TEntity item)
        {
            await _context.SaveAsync(item);
        }

        /// <inheritdoc />.
        public async Task AddRangeAsync(IEnumerable<TEntity> items)
        {
            var enumerable = items.ToList();

            while (enumerable.Any())
            {
                var batchWrite = _context.CreateBatchWrite<TEntity>();

                batchWrite.AddPutItems(enumerable.Take(25));

                await batchWrite.ExecuteAsync();

                items = enumerable.Skip(25);
            };
        }

        /// <inheritdoc />.
        public async Task RemoveRangeAsync(IEnumerable<TEntity> items)
        {
            var enumerable = items.ToList();
            
            while (enumerable.Any())
            {
                var batchWrite = _context.CreateBatchWrite<TEntity>();

                batchWrite.AddDeleteItems(enumerable.Take(25));

                await batchWrite.ExecuteAsync();

                items = enumerable.Skip(25);
            };
        }

        #endregion
    }
}
