﻿using System;
using Microservice.Value.DomainLogic.Enums;

namespace Microservice.Value.DomainLogic.Models.Search
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
