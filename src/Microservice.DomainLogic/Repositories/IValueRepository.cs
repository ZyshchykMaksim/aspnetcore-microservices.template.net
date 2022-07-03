using System;
using System.Threading.Tasks;
using Microservice.DataAccess.DB.MSSQL;
using Microservice.DataAccess.DB.MSSQL.Pagination;
using Microservice.DomainLogic.Models;

namespace Microservice.DomainLogic.Repositories
{
    public interface IValueRepository : IRepository<Domain.Value>
    {
        /// <summary>
        /// Gets value by unique identifier.
        /// </summary>
        /// <param name="valueId">The unique identifier of value.</param>
        /// <returns></returns>
        Task<Domain.Value> GetByIdAsync(Guid valueId);

        /// <summary>
        /// Gets value by name.
        /// </summary>
        /// <param name="strName">The name of value.</param>
        /// <returns></returns>
        Task<Domain.Value> GetByNameAsync(string strName);

        /// <summary>
        /// Get values by search terms.
        /// </summary>
        /// <param name="searchTermValue">The search terms of value.</param>
        /// <returns></returns>
        Task<PagedResult<Domain.Value>> GetAsync(SearchTermValue searchTermValue);
    }
}
