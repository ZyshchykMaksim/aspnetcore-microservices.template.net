using System;
using Microservice.DomainLogic.Enums;
using Microservice.DomainLogic.Models.Search;

namespace Microservice.DomainLogic.Models
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
