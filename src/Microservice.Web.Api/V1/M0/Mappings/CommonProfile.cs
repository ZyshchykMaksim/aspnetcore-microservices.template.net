using System;
using AutoMapper;
using Microservice.DataAccess.DB.MSSQL.Pagination;
using Microservice.Web.Api.V1.M0.Models;

namespace Microservice.Web.Api.V1.M0.Mappings
{
    /// <summary>
    /// Profile with <see cref="Common"/> automapper mappings.
    /// </summary>
    public class CommonProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonProfile"/> class.
        /// </summary>
        public CommonProfile()
        {
            CreateMap(typeof(PagedResult<>), typeof(PagedResultDto<>));
                

            CreateMap<string, DateTime>().ConvertUsing(s => DateTime.Parse(s));
            CreateMap<string, DateTime?>().ConvertUsing(s => s != null ? DateTime.Parse(s) : (DateTime?)null);
        }
    }
}
