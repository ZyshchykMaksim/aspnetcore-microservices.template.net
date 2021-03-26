using Microservice.Value.Web.Api.Services;
using Microservice.Value.Web.Api.Services.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Value.Web.Api.IoC
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IValueService, ValueService>();

            return services;
        }
    }
}
