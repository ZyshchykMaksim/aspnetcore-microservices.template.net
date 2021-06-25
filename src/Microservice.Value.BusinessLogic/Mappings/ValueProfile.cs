using AutoMapper;
using Microservice.Value.BusinessLogic.Models;

namespace Microservice.Value.BusinessLogic.Mappings
{
    /// <inheritdoc cref="Profile"/>
    public class ValueProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueProfile"/> class.
        /// </summary>
        public ValueProfile()
        {
            CreateMap<ValueDto, Domen.Entities.Value>().ReverseMap();
            CreateMap<CreateValueDto, Domen.Entities.Value>().ReverseMap();
        }
    }
}
