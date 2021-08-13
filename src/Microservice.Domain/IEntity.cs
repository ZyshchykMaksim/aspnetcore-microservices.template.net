namespace Microservice.Domain
{
    /// <summary>
    /// The interface of base entity.
    /// </summary>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets unique identifier for base entity.
        /// </summary>
        public TKey Id { get; set; }
    }
}
