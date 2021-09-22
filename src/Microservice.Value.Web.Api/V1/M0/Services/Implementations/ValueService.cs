using System;
using System.Threading.Tasks;
using AutoMapper;
using Dawn;
using Microservice.Value.DomainLogic.Models;
using Microservice.Value.DomainLogic.Models.Pagination;
using Microservice.Value.DomainLogic.Repositories;
using Microservice.Value.Web.Api.V1.M0.Models;

namespace Microservice.Value.Web.Api.V1.M0.Services.Implementations
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
        /// Gets the value.
        /// </summary>
        /// <param name="searchValueDto">The request to search value.</param>
        /// <returns></returns>
        public async Task<PagedResultDto<ResponseValueDto>> GetAsync(RequestSearchTermValueDto searchValueDto)
        {
            var searchValueMapp = _mapper.Map<RequestSearchTermValueDto, SearchTermValue>(searchValueDto);

            var valuesEntity = await _valueRepository.GetAsync(searchValueMapp);
            var valuesMapp = _mapper.Map<PagedResult<Entities.Value>, PagedResultDto<ResponseValueDto>>(valuesEntity);

            return valuesMapp;
        }

        /// <inheritdoc />
        public async Task<ResponseValueDto> GetByIdAsync(Guid valueId)
        {
            if (valueId == Guid.Empty)
            {
                return null;
            }

            var valueEntity = await _valueRepository.GetByIdAsync(valueId);

            return _mapper.Map<Entities.Value, ResponseValueDto>(valueEntity); ;
        }

        /// <inheritdoc />
        public async Task<ResponseValueDto> AddAsync(RequestCreateValueDto createValue)
        {
            Guard.Argument(() => createValue).NotNull();

            var valueEntityMapp = _mapper.Map<RequestCreateValueDto, Entities.Value>(createValue);
            var valueEntity = await _valueRepository.AddAsync(valueEntityMapp);

            return _mapper.Map<Entities.Value, ResponseValueDto>(valueEntity);
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

            _mapper.Map<RequestUpdateValueDto, Entities.Value>(updateValueDto, existingValue);
            await _valueRepository.UpdateAsync(existingValue, false, updateValueDto.RowVersion);

            return _mapper.Map<Entities.Value, ResponseValueDto>(existingValue);
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
