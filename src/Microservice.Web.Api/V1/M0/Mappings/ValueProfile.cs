using AutoMapper;
using Microservice.DomainLogic.Models;
using Microservice.Web.Api.V1.M0.Models;

namespace Microservice.Web.Api.V1.M0.Mappings
{
    /// <inheritdoc cref="Profile"/>
    public class ValueProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueProfile"/> class.
        /// </summary>
        public ValueProfile()
        {
            CreateMap<ResponseValueDto, Domain.Value>().ReverseMap();
            CreateMap<RequestCreateValueDto, Domain.Value>().ReverseMap();
            CreateMap<RequestUpdateValueDto, Domain.Value>().ReverseMap();
            CreateMap<RequestSearchTermValueDto, SearchTermValue>().ReverseMap();
        }
    }
}
