using System;

namespace Microservice.Value.Web.Api.Models
{
    public class ValueDto
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
    }
}
