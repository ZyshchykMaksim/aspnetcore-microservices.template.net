using EasyCaching.Core.Configurations;
using EasyCaching.Core.DistributedLock;
using EasyCaching.InMemory;
using EasyCaching.Redis.DistributedLock;
using EasyCaching.Serialization.SystemTextJson.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Web.Api.IoC
{
    public static class CachingExtension
    {
        public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLZ4Compressor();
            services.AddEasyCaching(options =>
            {
                var defaultSerializerName = "default-serializer-json";
                options.WithSystemTextJson(defaultSerializerName);
                options.UseInMemory(config =>
                {
                    config.SerializerName = defaultSerializerName;
                    config.DBConfig = new InMemoryCachingOptions
                    {
                        ExpirationScanFrequency = 60
                    };
                }, "inmemory");

                //use redis cache that named redis1
                options.UseRedis(config =>
                {
                    config.LockMs = 5000;
                    config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
                    config.SerializerName = defaultSerializerName;
                }, "redis_dev");
                
                options.UseRedisLock();
            });
            
            services.AddSingleton<IDistributedLockFactory>(x => x.GetRequiredService<RedisLockFactory>());

            return services;
        }
    }
}
