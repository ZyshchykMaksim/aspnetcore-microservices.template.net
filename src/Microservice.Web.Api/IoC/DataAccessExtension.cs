using System.Data;
using System.Reflection;
using Microservice.DataAccess.DB.MSSQL;
using Microservice.DomainLogic.Database;
using Microservice.DomainLogic.V1.M0.Repositories;
using Microservice.DomainLogic.V1.M0.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Web.Api.IoC
{
    public static class DataAccessExtension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var t = typeof(ValueContext);
            var assembly = Assembly.GetAssembly(t);

            if (assembly is null)
            {
                throw new DataException(nameof(assembly));
            }

            services.AddDbContext<ValueContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ValueConnection"), x => 
                    x.MigrationsAssembly(assembly.GetName().Name)));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

            return services;
        }
    }
}

