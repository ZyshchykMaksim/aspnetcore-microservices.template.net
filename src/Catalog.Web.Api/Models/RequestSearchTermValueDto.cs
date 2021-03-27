using System;
using Microservice.Domain.Models.Search;
using Microservice.Value.DomainLogic.Enums;

namespace Microservice.Value.Web.Api.Models
{
    public class RequestSearchTermValueDto : OrderedQuerySearchBase<ValueOrderBy>
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
