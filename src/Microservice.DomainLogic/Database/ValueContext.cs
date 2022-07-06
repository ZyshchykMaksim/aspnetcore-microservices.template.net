using Microservice.DataAccess.DB.MSSQL;
using Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.DomainLogic.Database
{
    public class ValueContext : DbContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextBase"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public ValueContext(DbContextOptions<ValueContext> options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }
    }
}
