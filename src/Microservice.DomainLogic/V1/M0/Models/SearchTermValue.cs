using System;
using Microservice.DomainLogic.V1.M0.Enums;
using Microservice.DomainLogic.V1.M0.Models.Search;

namespace Microservice.DomainLogic.V1.M0.Models
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
