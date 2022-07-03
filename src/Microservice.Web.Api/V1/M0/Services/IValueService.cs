using System;
using System.Threading.Tasks;
using Microservice.Web.Api.V1.M0.Models;

namespace Microservice.Web.Api.V1.M0.Services
{
    /// <summary>
    /// Allows to manage value data.
    /// </summary>
    public interface IValueService
    {
        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="searchValueDto">The request to search value.</param>
        /// <returns></returns>
        Task<PagedResultDto<ResponseValueDto>> GetAsync(RequestSearchTermValueDto searchValueDto);

        /// <summary>
        /// Gets the value by unique identifier.
        /// </summary>
        /// <param name="valueId">The unique identifier of value.</param>
        /// <returns></returns>
        Task<ResponseValueDto> GetByIdAsync(Guid valueId);

        /// <summary>
        /// Adds a new value.
        /// </summary>
        /// <param name="createValue">The object of value.</param>
        /// <returns></returns>
        Task<ResponseValueDto> AddAsync(RequestCreateValueDto createValue);

        /// <summary>
        /// Updates the existing value.
        /// </summary>
        /// <param name="valueId">The unique identifier of value.</param>
        /// <param name="updateValueDto">The update object of value.</param>
        /// <returns></returns>
        Task<ResponseValueDto> UpdateAsync(Guid valueId,  RequestUpdateValueDto updateValueDto);

        /// <summary>
        /// Deletes the value by unique identifier. NOTE: If the result is null, then know that the entity was not found to remove. 
        /// </summary>
        /// <param name="valueId">The unique identifier of value.</param>
        /// <returns></returns>
        Task<bool?> DeleteAsync(Guid valueId);
    }
}
