namespace Microservice.Entities.MongoDb
{
    /// <summary>
    /// The interface of base entity.
    /// </summary>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets unique identifier for base entity.
        /// </summary>
        TKey Id { get; set; }
    }
}
