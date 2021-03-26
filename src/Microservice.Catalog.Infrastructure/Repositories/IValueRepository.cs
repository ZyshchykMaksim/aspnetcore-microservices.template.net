using System;
using System.Threading.Tasks;
using Microservice.DataAccess.DB;

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
    }
}
