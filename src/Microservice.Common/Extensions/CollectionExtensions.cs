using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microservice.Common.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Collection{T}"/>.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="T:System.Collections.Generic.List`1" />.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="target"><see cref="ICollection{T}" /> target collection.</param>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="T:System.Collections.Generic.List`1" />.
        /// The collection itself cannot be null, but it can contain elements that are null,  if type T is a reference type.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="collection" /> is null.</exception>
        public static void AddRange<T>(this ICollection<T> target, IEnumerable<T> collection)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (T obj in collection)
            {
                target.Add(obj);
            }
        }

        /// <summary>
        /// Removes elements from the specified collection.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="target"><see cref="ICollection{T}" /> target collection.</param>
        /// <param name="collection">The collection whose elements should be removed.
        /// The collection itself cannot be null, but it can contain elements that are null,  if type T is a reference type.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="collection" /> is null.</exception>
        public static void RemoveRange<T>(this ICollection<T> target, IEnumerable<T> collection)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (T obj in collection)
            {
                target.Remove(obj);
            }
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
        public static IOrderedEnumerable<TSource> OrderByWithDirection<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            bool isDescending
        )
        {
            return isDescending ?
                source.OrderByDescending(keySelector) :
                source.OrderBy(keySelector);
        }
    }
}
