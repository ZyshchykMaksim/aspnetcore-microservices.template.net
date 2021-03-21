using System;

namespace Microservice.Value.Web.Api.Models
{
    public class ResponseValueModel
    {
        /// <summary>
        /// The unique identifier of catalog.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of catalog.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The data time when the catalog was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
