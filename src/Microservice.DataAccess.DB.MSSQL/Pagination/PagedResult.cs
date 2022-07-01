using System.Collections.Generic;

namespace Microservice.DataAccess.DB.MSSQL.Pagination
{
    /// <summary>
    /// The class provides pagination items.
    /// </summary>
    /// <typeparam name="T">the generic type.</typeparam>
    public class PagedResult<T> where T : class
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
