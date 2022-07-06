using Microservice.Web.Api.V1.M0.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Web.Api.IoC
{
    public static class DomainLogicExtension
    {
        public static IServiceCollection AddDomainLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDomainLogic_V1_0(configuration); // v1.0
            
            return services;
        }
    }
}
