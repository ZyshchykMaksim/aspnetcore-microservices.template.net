using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Console.DB.Mongo.Test.Entities;
using MongoDB.Driver;
using MongoFramework;
using MongoFramework.Linq;

namespace Console.DB.Mongo.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ValueDb");

            var values1 = database.GetCollection<Value>("Values");

           await values1.InsertOneAsync(new Value()
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid().ToString(),
                CreatedUtc = DateTime.UtcNow,
                LastModifiedBy = Guid.NewGuid().ToString(),
                LastModifiedUtc = DateTime.UtcNow
            });

            try
            {
                var connection = MongoDbConnection.FromConnectionString("mongodb://localhost:27017/ValueDb");
                
                using (var context = new MongoContext(connection))
                {
                    var newValue = new Value()
                    {
                        Id = Guid.NewGuid(),
                        CreatedBy = Guid.NewGuid().ToString(),
                        CreatedUtc = DateTime.UtcNow,
                        LastModifiedBy = Guid.NewGuid().ToString(),
                        LastModifiedUtc = DateTime.UtcNow
                    };

                    context.Values.Add(newValue);
                    await context.SaveChangesAsync();

                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("The data was saved successfully.");

                    //var itemDel = context.Values.FirstOrDefault();

                    //if (itemDel != null)
                    //{
                    //    context.Values.Remove(itemDel);

                    //    await context.SaveChangesAsync();
                    //}

                    var values = await context.Values.ToListAsync();

                    if (values != null && values.Any())
                    {
                        string strJsonValues = JsonSerializer.Serialize(values);

                        System.Console.WriteLine(strJsonValues);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(ex);
            }

            System.Console.ResetColor();
            System.Console.ReadKey(true);
        }
    }
}
