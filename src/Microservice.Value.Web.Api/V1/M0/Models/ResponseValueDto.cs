using System;

namespace Microservice.Value.Web.Api.V1.M0.Models
{
    public class ResponseValueDto
    {
        /// <summary>
        /// The unique identifier of value.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of value.
        /// </summary>s
        public string Description { get; set; }

        /// <summary>
        /// Date when value was created (in UTC timezone).
        /// </summary>
        public DateTime CreatedUtc { get; set; }

        /// <summary>
        /// The rowversion value is a sequential number that's incremented each time the resource is updated.
        /// If the resource being updated has been changed by another user, the value in the rowversion is different than the original value,
        /// so it helps to handle optimistic concurrency.
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
