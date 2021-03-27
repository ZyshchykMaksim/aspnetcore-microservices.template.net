using System;
using Microservice.Domain.Enums;

namespace Microservice.Domain.Models.Search
{
    /// <summary>
    /// The base class to search terms and order data.
    /// </summary>
    /// <typeparam name="TOrder">The type of the order.</typeparam>
    /// <seealso cref="SearchBase" />
    public class OrderedQuerySearchBase<TOrder> : QuerySearchBase where TOrder : struct, IComparable, IConvertible, IFormattable
    {
        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        public TOrder? OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the sort direction.
        /// </summary>
        public SortDirection? SortDirection { get; set; }
    }
}
