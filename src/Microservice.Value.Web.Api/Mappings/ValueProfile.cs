using AutoMapper;
using Microservice.Value.DomainLogic.Models;
using Microservice.Value.Web.Api.Models;

namespace Microservice.Value.Web.Api.Mappings
{
    /// <inheritdoc cref="Profile"/>
    public class ValueProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueProfile"/> class.
        /// </summary>
        public ValueProfile()
        {
            CreateMap<ResponseValueDto, Domen.Entities.Value>().ReverseMap();
            CreateMap<RequestCreateValueDto, Domen.Entities.Value>().ReverseMap();
            CreateMap<RequestUpdateValueDto, Domen.Entities.Value>().ReverseMap();
            CreateMap<RequestSearchTermValueDto, SearchTermValue>().ReverseMap();
        }
    }
}
