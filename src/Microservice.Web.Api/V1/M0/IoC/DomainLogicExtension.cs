using Microservice;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Web.Api.V1.M0.IoC
{
    public static class DomainLogicExtension
    {
        public static IServiceCollection AddDomainLogic_V1_0(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DomainLogic.V1.M0.Repositories.IValueRepository, DomainLogic.V1.M0.Repositories.Implementations.ValueRepository>();

            return services;
        }
    }
}
