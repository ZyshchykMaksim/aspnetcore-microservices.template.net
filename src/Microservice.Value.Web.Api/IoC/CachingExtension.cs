using EasyCaching.Core.Configurations;
using EasyCaching.Core.DistributedLock;
using EasyCaching.InMemory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Value.Web.Api.IoC
{
    public static class CachingExtension
    {
        public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLZ4Compressor();
            services.AddEasyCaching(options =>
            {
                options.UseInMemory(config =>
                {
                    config.DBConfig = new InMemoryCachingOptions
                    {
                        ExpirationScanFrequency = 60
                    };
                }, "inmemory");

                //use redis cache that named redis1
                options.UseRedis(config =>
                    {
                        config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
                    }, "localhost")
                    .WithJson("json")
                    .WithCompressor("json", "lz4");
            });

            return services;
        }
    }
}
