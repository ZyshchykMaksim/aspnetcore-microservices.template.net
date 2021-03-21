using System;

namespace Microservice.Domain
{
    /// <summary>
    /// The interface for audit.
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Id of the user who created record.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Date when resource was created (in UTC timezone).
        /// </summary>
        DateTime CreatedUtc { get; set; }

        /// <summary>
        /// Id of the user who updated record.
        /// </summary>
        string LastModifiedBy { get; set; }

        /// <summary>
        /// Date when resource was updated (in UTC timezone).
        /// </summary>
        DateTime LastModifiedUtc { get; set; }
    }
}
