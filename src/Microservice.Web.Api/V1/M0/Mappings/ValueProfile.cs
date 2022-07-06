using AutoMapper;

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
            CreateMap<V1.M0.Models.RequestCreateValueDto, Domain.Value>();
            CreateMap<V1.M0.Models.RequestUpdateValueDto, Domain.Value>();
            CreateMap<V1.M0.Models.ResponseValueDto, Domain.Value>();
            CreateMap<V1.M0.Models.RequestSearchTermValueDto, DomainLogic.V1.M0.Models.SearchTermValue>().ReverseMap();
        }
    }
}
