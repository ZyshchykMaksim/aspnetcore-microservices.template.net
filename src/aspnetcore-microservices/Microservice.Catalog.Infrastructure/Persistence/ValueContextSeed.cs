using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Microservice.Value.Infrastructure.Persistence
{
    public class ValueContextSeed
    {
        public static async Task SeedAsync(ValueContext orderContext, ILogger<ValueContextSeed> logger)
        {
            if (!orderContext.Values.Any())
            {
                var value1 = new Domen.Entities.Value()
                {
                    Name = "Value 1",
                    Description = "Value One"
                };

                var value2 = new Domen.Entities.Value()
                {
                    Name = "Value 2",
                    Description = "Value Two"
                };

                await orderContext.Values.AddRangeAsync(new List<Domen.Entities.Value>()
                {
                    value1, value2
                });


                await orderContext.SaveChangesAsync();

                logger.LogInformation("Seed database associated with context {DbContextName}", nameof(ValueContext));
            }
        }
    }
}
