using AutoMapper;
using Microservice.Value.DomainLogic.Models;
using Microservice.Value.Web.Api.V1.M0.Models;

namespace Microservice.Value.Web.Api.V1.M0.Mappings
{
    /// <inheritdoc cref="Profile"/>
    public class ValueProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueProfile"/> class.
        /// </summary>
        public ValueProfile()
        {
            CreateMap<ResponseValueDto, Entities.Value>().ReverseMap();
            CreateMap<RequestCreateValueDto, Entities.Value>().ReverseMap();
            CreateMap<RequestUpdateValueDto, Entities.Value>().ReverseMap();
            CreateMap<RequestSearchTermValueDto, SearchTermValue>().ReverseMap();
        }
    }
}
