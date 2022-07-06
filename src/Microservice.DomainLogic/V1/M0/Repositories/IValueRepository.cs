using System;
using System.Threading.Tasks;
using Microservice.DataAccess.DB.MSSQL;
using Microservice.DataAccess.DB.MSSQL.Pagination;
using Microservice.Domain.Entities;
using Microservice.DomainLogic.V1.M0.Models;

namespace Microservice.DomainLogic.V1.M0.Repositories
{
    public interface IValueRepository : IRepository<Value>
    {
        /// <summary>
        /// Gets value by unique identifier.
        /// </summary>
        /// <param name="valueId">The unique identifier of value.</param>
        /// <returns></returns>
        Task<Value> GetByIdAsync(Guid valueId);

        /// <summary>
        /// Gets value by name.
        /// </summary>
        /// <param name="strName">The name of value.</param>
        /// <returns></returns>
        Task<Value> GetByNameAsync(string strName);

        /// <summary>
        /// Get values by search terms.
        /// </summary>
        /// <param name="searchTermValue">The search terms of value.</param>
        /// <returns></returns>
        Task<PagedResult<Value>> GetAsync(SearchTermValue searchTermValue);
    }
}
