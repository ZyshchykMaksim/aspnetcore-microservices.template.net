using System;

namespace Microservice.Entities.MSSQL
{
    /// <summary>
    /// Indicates that entity supports soft delete.
    /// </summary>
    public interface ISoftDelitable
    {
        /// <summary>
        /// Id of the user who deleted record.
        /// </summary>
        string DeletedBy { get; set; }

        /// <summary>
        /// Date when resource was deleted (in UTC timezone).
        /// </summary>
        DateTime? DeletedUtc { get; set; }
    }
}
