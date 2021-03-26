using System;
using System.Collections.Generic;
using System.Linq;
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
            _valueRepository = Guard.Argument(valueRepository, nameof(valueRepository)).NotNull().Value;
            _mapper = Guard.Argument(mapper, nameof(mapper)).NotNull().Value;
        }

        #region Implementation of IValueService

        /// <summary>
        /// Gets all information about values.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ResponseValueDto>> GetAllAsync()
        {
            var values = await _valueRepository.GetAsync(x => !x.DeletedUtc.HasValue);

            return _mapper.Map<IEnumerable<Domen.Entities.Value>, IEnumerable<ResponseValueDto>>(values);
        }

        /// <inheritdoc />
        public async Task<ResponseValueDto> GetByIdAsync(Guid valueId)
        {
            if (valueId == Guid.Empty)
            {
                return null;
            }

            var valueEntity = await _valueRepository.GetByIdAsync(valueId);

            return _mapper.Map<Domen.Entities.Value, ResponseValueDto>(valueEntity); ;
        }

        /// <inheritdoc />
        public async Task<ResponseValueDto> AddAsync(RequestCreateValueDto createValue)
        {
            Guard.Argument(() => createValue).NotNull();

            var valueEntityMapp = _mapper.Map<RequestCreateValueDto, Domen.Entities.Value>(createValue);
            var valueEntity = await _valueRepository.AddAsync(valueEntityMapp);

            return _mapper.Map<Domen.Entities.Value, ResponseValueDto>(valueEntity);
        }

        /// <inheritdoc />
        public async Task<ResponseValueDto> UpdateAsync(Guid valueId, RequestUpdateValueDto updateValueDto)
        {
            Guard.Argument(() => updateValueDto).NotNull();

            if (valueId == Guid.Empty)
            {
                return null;
            }

            var existingValue = await _valueRepository.GetByIdAsync(valueId);

            if (existingValue == null)
            {
                return null;
            }

            _mapper.Map<RequestUpdateValueDto, Domen.Entities.Value>(updateValueDto, existingValue);
            await _valueRepository.UpdateAsync(existingValue, false, updateValueDto.RowVersion);

            return _mapper.Map<Domen.Entities.Value, ResponseValueDto>(existingValue);
        }

        /// <inheritdoc />
        public async Task<bool?> DeleteAsync(Guid valueId)
        {
            if (valueId == Guid.Empty)
            {
                return null;
            }

            var existingValue = await _valueRepository.GetByIdAsync(valueId);

            if (existingValue == null)
            {
                return null;
            }

            await _valueRepository.RemoveAsync(existingValue);

            return true;
        }

        #endregion
    }
}
