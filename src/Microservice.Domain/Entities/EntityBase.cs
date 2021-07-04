namespace Microservice.Domain.Entities
{
    /// <summary>
    /// The class of base entity.
    /// </summary>
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Gets unique identifier for base entity.
        /// </summary>
        public virtual TKey Id { get; set; }
    }
}
