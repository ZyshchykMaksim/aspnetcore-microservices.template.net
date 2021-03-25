using System.Threading.Tasks;
using Microservice.DataAccess.DB;

namespace Microservice.Value.DomainLogic.Repositories
{
    public interface IValueRepository : IRepository<Domen.Entities.Value>
    {
        /// <summary>
        /// Get value by name.
        /// </summary>
        /// <param name="strName">The name of value.</param>
        /// <returns></returns>
        Task<Domen.Entities.Value> GetByNameAsync(string strName);
    }
}
