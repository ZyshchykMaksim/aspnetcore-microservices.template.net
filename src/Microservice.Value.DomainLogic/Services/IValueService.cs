using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Value.BusinessLogic.Models;

namespace Microservice.Value.BusinessLogic.Services
{
    /// <summary>
    /// Allows to manage value data.
    /// </summary>
    public interface IValueService
    {
        /// <summary>
        /// Gets the value by unique identifier.
        /// </summary>
        /// <param name="valueId">The unique identifier of value.</param>
        /// <returns></returns>
        Task<ValueDto> GetByIdAsync(Guid valueId);

        /// <summary>
        /// Adds a new value.
        /// </summary>
        /// <param name="createValue">The object of value.</param>
        /// <returns></returns>
        Task<ValueDto> AddAsync(CreateValueDto createValue);

        /// <summary>
        /// Updates the existing value.
        /// </summary>
        /// <param name="valueId">The unique identifier of value.</param>
        /// <param name="updateValueDto">The update object of value.</param>
        /// <returns></returns>
        Task<ValueDto> UpdateAsync(Guid valueId,  UpdateValueDto updateValueDto);

        /// <summary>
        /// Deletes the value by unique identifier.
        /// </summary>
        /// <param name="valueId">The unique identifier of value.</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Guid valueId);
    }
}
