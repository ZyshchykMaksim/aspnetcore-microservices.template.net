using System.Data;
using System.Reflection;
using Microservice.DataAccess.DB.MSSQL;
using Microservice.Value.DomainLogic.Persistence;
using Microservice.Value.DomainLogic.Repositories;
using Microservice.Value.DomainLogic.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Value.Web.Api.IoC
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
            services.AddScoped<IValueRepository, ValueRepository>();
             
            return services;
        }
    }
}

