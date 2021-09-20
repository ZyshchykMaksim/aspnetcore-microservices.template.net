using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microservice.Value.DomainLogic.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Microservice.DataAccess.DB.MSSQL.Extensions
{
    /// <summary>
    /// The extension methods for the IQueryable type.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Gets the paged result.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>Paged result.</returns>
        /// <exception cref="ArgumentNullException">target</exception>
        public static PagedResult<T> GetPagedResult<T>(
            this IQueryable<T> target,
            int? startIndex = null,
            int? limit = null
        ) where T : class, new()
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var total = target.LongCount();

            if (startIndex != null)
            {
                target = target.Skip(startIndex.Value);
            }

            if (limit != null)
            {
                target = target.Take(limit.Value);
            }

            return new PagedResult<T>()
            {
                Results = target.ToList(),
                Skip = startIndex ?? 0,
                Take = limit ?? 0,
                Total = total
            };
        }

        /// <summary>
        /// Gets the paged result (async version).
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>Paged result.</returns>
        /// <exception cref="ArgumentNullException">target</exception>
        public static async Task<PagedResult<T>> GetPagedResultAsync<T>(
            this IQueryable<T> target,
            int? startIndex = null,
            int? limit = null
        ) where T : class, new()
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var total = await target.LongCountAsync();

            if (startIndex != null)
            {
                target = target.Skip(startIndex.Value);
            }

            if (limit != null)
            {
                target = target.Take(limit.Value);
            }

            return new PagedResult<T>()
            {
                Results = await target.ToListAsync(),
                Skip = startIndex ?? 0,
                Take = limit ?? 0,
                Total = total
            };
        }

        /// <summary>
        /// Gets the scroll result.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>Scrolled result.</returns>
        /// <exception cref="ArgumentNullException">target</exception>
        public static IReadOnlyList<T> GetScrollResult<T>(
            this IQueryable<T> target,
            int? startIndex = null,
            int? limit = null
        ) where T : class, new()
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (startIndex != null)
            {
                target = target.Skip(startIndex.Value);
            }

            if (limit != null)
            {
                target = target.Take(limit.Value);
            }

            return target.ToList();
        }

        /// <summary>
        /// Gets the scroll result (async version).
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>Scrolled result.</returns>
        /// <exception cref="ArgumentNullException">target</exception>
        public static async Task<IReadOnlyList<T>> GetScrollResultAsync<T>(
            this IQueryable<T> target,
            int? startIndex = null,
            int? limit = null
        ) where T : class, new()
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (startIndex != null)
            {
                target = target.Skip(startIndex.Value);
            }

            if (limit != null)
            {
                target = target.Take(limit.Value);
            }

            return await target.ToListAsync();
        }
        
        /// <summary>
        /// Orders with direction.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="isDescending">if set to <c>true</c> [is descending].</param>
        /// <returns>Ordered result.</returns>
        public static IOrderedQueryable<TSource> OrderByWithDirection<TSource, TKey>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector,
            bool isDescending
        )
        {
            return isDescending ?
                source.OrderByDescending(keySelector) :
                source.OrderBy(keySelector);
        }
    }
}
