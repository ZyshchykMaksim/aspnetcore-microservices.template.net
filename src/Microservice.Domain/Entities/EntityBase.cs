using System.ComponentModel.DataAnnotations;

namespace Microservice.Domain.Entities
{
    /// <summary>
    /// The class of base entity.
    /// </summary>
    public abstract class EntityBase<TKey>
    {
        /// <summary>
        /// Gets unique identifier for base entity.
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the row version for entity.
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
