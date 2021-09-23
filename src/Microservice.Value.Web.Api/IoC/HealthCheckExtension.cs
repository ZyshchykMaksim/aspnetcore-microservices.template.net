using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Value.DomainLogic.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Microservice.Value.Web.Api.IoC
{
    public static class HealthCheckExtension
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<ValueContext>("SQL Database Health", HealthStatus.Healthy, new[] { "mssql ", "database" })
                .AddRedis("localhost", "Redis Health", HealthStatus.Healthy, new[] { "redis", "cache" });

            return services;
        }
    }
}
