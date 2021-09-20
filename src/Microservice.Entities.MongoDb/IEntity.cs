using System;

namespace Microservice.Entities.MongoDb
{
    /// <summary>
    /// This class represents a basic document that can be stored in MongoDb.
    /// Your document must implement this class in order for the MongoDbRepository to handle them.
    /// </summary>
    public interface IEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// The primary key, which must be decorated with the [BsonId] attribute 
        /// if you want the MongoDb C# driver to consider it to be the document ID.
        /// </summary>
        TKey Id { get; set; }

        /// <summary>
        /// A version number, to indicate the version of the schema.
        /// </summary>
        int Version { get; set; }
    }
}
