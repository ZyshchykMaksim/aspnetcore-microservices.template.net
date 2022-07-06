using System;
using Microservice.DomainLogic.V1.M0.Enums;

namespace Microservice.DomainLogic.V1.M0.Models.Search
{
    /// <summary>
    /// OrderedSearchDto.
    /// </summary>
    /// <typeparam name="TOrder">The type of the order.</typeparam>
    /// <seealso cref="SearchBase" />
    public class OrderedSearchBase<TOrder> : SearchBase where TOrder : struct, IComparable, IConvertible, IFormattable
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
