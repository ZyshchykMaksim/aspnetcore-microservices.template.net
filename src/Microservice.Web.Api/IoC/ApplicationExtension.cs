using Microservice.Web.Api.V1.M0.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Web.Api.IoC
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication_V1_0(configuration);

            return services;
        }
    }
}