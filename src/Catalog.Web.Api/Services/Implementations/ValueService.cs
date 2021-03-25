using System;
using System.Threading.Tasks;
using AutoMapper;
using Dawn;
using Microservice.Value.DomainLogic.Repositories;
using Microservice.Value.Web.Api.Models;

namespace Microservice.Value.Web.Api.Services.Implementations
{
    /// <inheritdoc cref="IValueService"/>
    public class ValueService : IValueService
    {
        private readonly IValueRepository _valueRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueService"/> class.
        /// </summary>
        public ValueService(
            IValueRepository valueRepository,
            IMapper mapper)
        {
            _valueRepository = valueRepository ?? throw new ArgumentNullException(nameof(valueRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #region Implementation of IValueService

        /// <inheritdoc />
        public async Task<ValueDto> GetByIdAsync(Guid valueId)
        {
            if (valueId == Guid.Empty)
            {
                return null;
            }

            var valueEntity = await _valueRepository.GetByIdAsync(valueId);
            var valueMapp = _mapper.Map<Domen.Entities.Value, ValueDto>(valueEntity);

            return valueMapp;
        }

        /// <inheritdoc />
        public async Task<ValueDto> AddAsync(CreateValueDto createValue)
        {
            Guard.Argument(() => createValue).NotNull();

            var valueEntityMapp = _mapper.Map<CreateValueDto, Domen.Entities.Value>(createValue);
            var valueEntity = await _valueRepository.AddAsync(valueEntityMapp);
            var valueMapp = _mapper.Map<Domen.Entities.Value, ValueDto>(valueEntity);

            return valueMapp;
        }

        /// <inheritdoc />
        public Task<ValueDto> UpdateAsync(Guid valueId, UpdateValueDto updateValueDto)
        {
            throw new NotImplementedException();

            Guard.Argument(() => valueId).NotDefault();
            Guard.Argument(() => updateValueDto).NotNull();
        }

        /// <inheritdoc />
        public Task<bool> DeleteAsync(Guid valueId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
