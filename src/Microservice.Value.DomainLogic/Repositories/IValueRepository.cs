using System;
using System.Threading.Tasks;
using Microservice.DataAccess.DB.MSSQL;
using Microservice.Value.DomainLogic.Models;
using Microservice.Value.DomainLogic.Models.Pagination;

namespace Microservice.Value.DomainLogic.Repositories
{
    public interface IValueRepository : IRepository<Domen.Entities.Value>
    {
        /// <summary>
        /// Gets value by unique identifier.
        /// </summary>
        /// <param name="valueId">The unique identifier of value.</param>
        /// <returns></returns>
        Task<Domen.Entities.Value> GetByIdAsync(Guid valueId);

        /// <summary>
        /// Gets value by name.
        /// </summary>
        /// <param name="strName">The name of value.</param>
        /// <returns></returns>
        Task<Domen.Entities.Value> GetByNameAsync(string strName);

        /// <summary>
        /// Get values by search terms.
        /// </summary>
        /// <param name="searchTermValue">The search terms of value.</param>
        /// <returns></returns>
        Task<PagedResult<Domen.Entities.Value>> GetAsync(SearchTermValue searchTermValue);
    }
}
