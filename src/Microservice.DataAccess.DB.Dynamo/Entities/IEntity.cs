using System;

namespace Microservice.DataAccess.DB.Dynamo.Entities
{
    /// <summary>
    /// The interface of base entity.
    /// </summary>
    public interface IEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets unique identifier for base entity.
        /// </summary>
        TKey Id { get; set; }
    }
}
