using System.Collections.Generic;

namespace Microservice.Web.Api.V1.M0.Models
{
    /// <summary>
    /// The class provides pagination items.
    /// </summary>
    /// <typeparam name="T">the generic type.</typeparam>
    public class PagedResultDto<T>
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public IReadOnlyList<T> Results { get; set; }

        /// <summary>
        /// Skip used in the request.
        /// </summary>
        public long Skip { get; set; }

        /// <summary>
        /// Take used in the request.
        /// </summary>
        public long Take { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public long Total { get; set; }
    }
}
