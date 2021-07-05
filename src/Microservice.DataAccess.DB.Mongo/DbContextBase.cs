using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using MongoDB.Driver;

namespace Microservice.DataAccess.DB.Mongo
{
    public class DbContextBase
    {
        public MongoClient Client { get; private set; }

        public IMongoDatabase Database { get; private set; }

        protected DbContextBase([NotNull] DbContextOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Connection))
            {
                throw new ArgumentNullException(nameof(options.Connection));
            }

            if (string.IsNullOrWhiteSpace(options.Database))
            {
                throw new ArgumentNullException(nameof(options.Database));
            }

            Client = new MongoClient(options.Connection);
        }
    }
}
