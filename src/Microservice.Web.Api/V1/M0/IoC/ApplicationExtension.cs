using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Web.Api.V1.M0.IoC
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication_V1_0(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<V1.M0.Services.IValueService, V1.M0.Services.Implementations.ValueService>();

            return services;
        }
    }
}