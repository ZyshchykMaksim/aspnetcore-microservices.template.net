using Console.DB.Mongo.Test.Entities;
using Microservice.DataAccess.DB.Mongo;
using MongoFramework;

namespace Console.DB.Mongo.Test
{
    public class MongoContext : DbContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextBase"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public MongoContext(IMongoDbConnection options) : base(options)
        {
        }

        public MongoDbSet<Value> Values { get; set; }
    }
}
