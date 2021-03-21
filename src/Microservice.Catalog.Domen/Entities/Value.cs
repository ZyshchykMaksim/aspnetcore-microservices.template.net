using Microservice.Domain.Entities;

namespace Microservice.Value.Domen.Entities
{
    /// <summary>
    /// The class for catalog.
    /// </summary>
    public class Value : EntityAuditBase
    {
        /// <summary>
        /// The name of value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of value.
        /// </summary>s
        public string Description { get; set; }
    }
}
