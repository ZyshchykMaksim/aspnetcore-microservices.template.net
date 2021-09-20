using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microservice.Common.Extensions;
using Microservice.DataAccess.DB.MSSQL;
using Microservice.DataAccess.DB.MSSQL.Extensions;
using Microservice.Entities.MSSQL.Enums;
using Microservice.Entities.MSSQL.Models.Pagination;
using Microservice.Value.DomainLogic.Enums;
using Microservice.Value.DomainLogic.Models;
using Microservice.Value.DomainLogic.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Value.DomainLogic.Repositories.Implementations
{
    public class ValueRepository : RepositoryBase<Guid, Domen.Entities.Value>, IValueRepository
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

        /// <inheritdoc cref="IValueRepository"/>
        public async Task<Domen.Entities.Value> GetByIdAsync(Guid valueId)
        {
            if (valueId == Guid.Empty)
            {
                return null;
            }

            return await _dbContext.Values.FirstOrDefaultAsync(x => x.Id == valueId && !x.DeletedUtc.HasValue);
        }

        /// <inheritdoc cref="IValueRepository"/>
        public async Task<Domen.Entities.Value> GetByNameAsync(string strName)
        {
            if (string.IsNullOrWhiteSpace(strName))
            {
                return null;
            }

            return await _dbContext.Values.FirstOrDefaultAsync(x => x.Name == strName && !x.DeletedUtc.HasValue);
        }

        /// <inheritdoc cref="IValueRepository"/>
        public async Task<PagedResult<Domen.Entities.Value>> GetAsync(SearchTermValue searchTermValue)
        {
            Expression<Func<Domen.Entities.Value, bool>> searchExpression = BuildSearchValuesExpression(searchTermValue);
            Expression<Func<Domen.Entities.Value, dynamic>> orderExpression = BuildValuesOrderExpression(searchTermValue?.OrderBy);

            var values = await _dbContext.Values
                .Where(searchExpression)
                .OrderByWithDirection(orderExpression, searchTermValue?.SortDirection == null || searchTermValue.SortDirection == SortDirection.Desc)
                .GetPagedResultAsync(searchTermValue?.Skip, searchTermValue?.Take);

            return values;
        }

        #endregion

        #region Private methods

        private Expression<Func<Domen.Entities.Value, bool>> BuildSearchValuesExpression(SearchTermValue searchTermValue)
        {
            Expression<Func<Domen.Entities.Value, bool>> expression = e => !e.DeletedUtc.HasValue;

            if (searchTermValue != null)
            {
                if (!string.IsNullOrEmpty(searchTermValue.Q))
                {
                    IEnumerable<string> terms = searchTermValue.Q.Split(' ').Where(e => !string.IsNullOrWhiteSpace(e.ToLower()));

                    foreach (string term in terms)
                    {
                        expression = expression.And(e => e.Name.ToLower().Contains(term));
                    }
                }

                if (searchTermValue.CreatedAfterUtc.HasValue)
                {
                    expression = expression.And(e => e.CreatedUtc >= searchTermValue.CreatedAfterUtc.Value);
                }

                if (searchTermValue.CreatedBeforeUtc.HasValue)
                {
                    expression = expression.And(e => e.CreatedUtc <= searchTermValue.CreatedBeforeUtc.Value);
                }
            }

            return expression;
        }

        private Expression<Func<Domen.Entities.Value, object>> BuildValuesOrderExpression(ValueOrderBy? orderBy)
        {
            Expression<Func<Domen.Entities.Value, dynamic>> orderExpression = e => e.CreatedUtc;

            if (orderBy.HasValue)
            {
                orderExpression = orderBy switch
                {
                    ValueOrderBy.Created => e => e.CreatedUtc,
                    ValueOrderBy.Updated => e => e.LastModifiedUtc,
                    _ => e => e.CreatedUtc
                };
            }

            return orderExpression;
        }
    }

    #endregion
}

