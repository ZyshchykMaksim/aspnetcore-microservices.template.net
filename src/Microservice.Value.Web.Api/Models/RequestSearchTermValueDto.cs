using System;
using System.ComponentModel.DataAnnotations;
using Microservice.Common.Web.DataAnnotations;
using Microservice.Entities.MSSQL.Models.Search;
using Microservice.Value.DomainLogic.Enums;

namespace Microservice.Value.Web.Api.Models
{
    public class RequestSearchTermValueDto : OrderedQuerySearchBase<ValueOrderBy>
    {
        /// <summary>
        /// Gets or sets the datetime created after UTC.
        /// </summary>
        public DateTime? CreatedAfterUtc { get; set; }

        /// <summary>
        ///Gets or sets the datetime created before UTC.
        /// </summary>
        [GreaterThan(
            nameof(CreatedAfterUtc),
            PassOnNull = true,
            ErrorMessage = @"{0} must be greater than {1}"
        )]
        public DateTime? CreatedBeforeUtc { get; set; }

        /// <summary>
        /// Gets or sets the pagination (skip).
        /// </summary>
        [Range(
            0,
            int.MaxValue,
            ErrorMessage = @"{0} must contain number of elements within range {1} - {2}"
        )]
        public override int Skip { get; set; }

        /// <summary>
        ///  Gets or sets the pagination (take).
        /// </summary>
        [Range(
            1,
            int.MaxValue,
            ErrorMessage = @"{0} must contain number of elements within range {1} - {2}"
        )]
        public override int Take { get; set; }
    }
}
