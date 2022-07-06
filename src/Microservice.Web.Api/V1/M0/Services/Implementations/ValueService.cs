using System;
using System.Threading.Tasks;
using AutoMapper;
using Dawn;
using EasyCaching.Core;
using EasyCaching.Core.DistributedLock;
using Microservice.DataAccess.DB.MSSQL.Pagination;
using Microservice.Domain.Entities;
using Microservice.DomainLogic.V1.M0.Models;
using Microservice.DomainLogic.V1.M0.Repositories;
using Microservice.Web.Api.V1.M0.Models;

namespace Microservice.Web.Api.V1.M0.Services.Implementations
{
    /// <inheritdoc cref="IValueService"/>
    public class ValueService : IValueService
    {
        private readonly IValueRepository _valueRepository;
        private readonly IRedisCachingProvider _redisCachingProvider;
        private readonly IDistributedLockFactory _distributedLockFactory;

        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueService"/> class.
        /// </summary>
        public ValueService(
            IValueRepository valueRepository,
            IRedisCachingProvider redisCachingProvider,
            IDistributedLockFactory distributedLockFactory,
            IMapper mapper)
        {
            _valueRepository = Guard.Argument(valueRepository, nameof(valueRepository)).NotNull().Value;
            _redisCachingProvider = Guard.Argument(redisCachingProvider, nameof(redisCachingProvider)).NotNull().Value;
            _distributedLockFactory =
                Guard.Argument(distributedLockFactory, nameof(distributedLockFactory)).NotNull().Value;
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
            await using (var distributedLock = _distributedLockFactory.CreateLock(
                             _redisCachingProvider.RedisName,
                             "lock"))
            {
                if (await distributedLock.LockAsync(new TimeSpan(0, 1, 0).Milliseconds))
                {
                  
                }
            }
            
            return null;

            var searchValueMapp = _mapper.Map<RequestSearchTermValueDto, SearchTermValue>(searchValueDto);

            var valuesEntity = await _valueRepository.GetAsync(searchValueMapp);
            var valuesMapp = _mapper.Map<PagedResult<Value>, PagedResultDto<ResponseValueDto>>(valuesEntity);

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

            return _mapper.Map<Value, ResponseValueDto>(valueEntity);
            ;
        }

        /// <inheritdoc />
        public async Task<ResponseValueDto> AddAsync(RequestCreateValueDto createValue)
        {
            Guard.Argument(() => createValue).NotNull();

            var valueEntityMapp = _mapper.Map<RequestCreateValueDto, Value>(createValue);
            var valueEntity = await _valueRepository.AddAsync(valueEntityMapp);

            return _mapper.Map<Value, ResponseValueDto>(valueEntity);
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

            _mapper.Map<RequestUpdateValueDto, Value>(updateValueDto, existingValue);
            await _valueRepository.UpdateAsync(existingValue, false, updateValueDto.RowVersion);

            return _mapper.Map<Value, ResponseValueDto>(existingValue);
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