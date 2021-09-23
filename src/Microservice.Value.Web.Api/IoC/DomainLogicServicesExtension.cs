using Microservice.Value.Web.Api.V1.M0.Services;
using Microservice.Value.Web.Api.V1.M0.Services.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Value.Web.Api.IoC
{
    public static class DomainLogicServicesExtension
    {
        public static IServiceCollection AddDomainLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IValueService, ValueService>();

            return services;
        }
    }
}
