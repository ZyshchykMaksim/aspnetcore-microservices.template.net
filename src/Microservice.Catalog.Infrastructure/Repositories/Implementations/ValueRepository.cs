using System;
using System.Threading.Tasks;
using Microservice.DataAccess.DB.EF;
using Microservice.Value.DomainLogic.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Value.DomainLogic.Repositories.Implementations
{
    public class ValueRepository : RepositoryBase<Domen.Entities.Value>, IValueRepository
    {
        private readonly ValueContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueRepository"/> class.
        /// </summary>
        public ValueRepository(ValueContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #region Implementation of IValueRepository

        /// <summary>
        /// Gets value by unique identifier.
        /// </summary>
        /// <param name="strName">The name of value.</param>
        /// <returns></returns>
        public Task<Domen.Entities.Value> GetByIdAsync(string strName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets value by unique identifier.
        /// </summary>
        /// <param name="valueId">The unique identifier of value.</param>
        /// <returns></returns>
        public async Task<Domen.Entities.Value> GetByIdAsync(Guid valueId)
        {
            if (valueId == Guid.Empty)
            {
                return null;
            }

            return await _dbContext.Values.FirstOrDefaultAsync(x => x.Id == valueId && !x.DeletedUtc.HasValue);
        }

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

            return await _dbContext.Values.FirstOrDefaultAsync(x => x.Name == strName && !x.DeletedUtc.HasValue);
        }

        #endregion
    }
}
