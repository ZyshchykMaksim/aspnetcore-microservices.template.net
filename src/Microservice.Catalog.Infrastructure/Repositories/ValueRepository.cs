using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.DB.EF;
using Microservice.Value.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Value.Infrastructure.Repositories
{
    public class ValueRepository : RepositoryBase<Domen.Entities.Value>, IValueRepository
    {
        private readonly ValueContext _dbContext;

        public ValueRepository(ValueContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #region Implementation of IValueRepository

        /// <summary>
        /// Get value by name.
        /// </summary>
        /// <param name="strName">The name of value.</param>
        /// <returns></returns>
        public async Task<Domen.Entities.Value> GetByNameAsync(string strName)
        {
            if (string.IsNullOrWhiteSpace(strName))
            {
                return null;
            }

            return await _dbContext.Values.FirstOrDefaultAsync(x => x.Name == strName);
        }

        #endregion
    }
}
