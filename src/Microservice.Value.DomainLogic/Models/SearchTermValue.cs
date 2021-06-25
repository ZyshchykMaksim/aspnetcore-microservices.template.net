using System;
using Microservice.Domain.Models.Search;
using Microservice.Value.DomainLogic.Enums;

namespace Microservice.Value.DomainLogic.Models
{
    public class SearchTermValue : OrderedQuerySearchBase<ValueOrderBy>
    {
        /// <summary>
        /// The datetime created after UTC.
        /// </summary>
        public DateTime? CreatedAfterUtc { get; set; }

        /// <summary>
        /// The datetime created before UTC.
        /// </summary>
        public DateTime? CreatedBeforeUtc { get; set; }
    }
}
