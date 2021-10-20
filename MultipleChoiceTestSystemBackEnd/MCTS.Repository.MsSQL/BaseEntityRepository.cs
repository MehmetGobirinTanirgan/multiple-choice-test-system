using MCTS.Core.CoreEntites.Concrete;
using MCTS.Core.RepositoryAbstractions;
using MCTS.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MCTS.Repository.MsSQL
{
    public class BaseEntityRepository<T> : IBaseEntityRepository<T> where T : BaseEntity
    {
        private readonly MctsContext mctsContext;

        public BaseEntityRepository(MctsContext mctsContext)
        {
            this.mctsContext = mctsContext;
        }

        public async Task AddAsync(T entity)
        {
            await mctsContext.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await mctsContext.Set<T>().AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await Task.FromResult(mctsContext.Set<T>().AsNoTracking().Any(exp));
        }

        public void Delete(T entity)
        {
            mctsContext.Set<T>().Remove(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            mctsContext.Set<T>().Remove(await GetOneByIDAsync(id));
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> exp)
        {
            mctsContext.Set<T>().Remove(await GetOneByExpressionAsync(exp));
        }

        public IQueryable<T> GetAll()
        {
            return mctsContext.Set<T>();
        }

        public IQueryable<T> GetListByExpression(Expression<Func<T, bool>> exp)
        {
            return mctsContext.Set<T>().Where(exp);
        }

        public async Task<T> GetOneByExpressionAsync(Expression<Func<T, bool>> exp)
        {
            return await mctsContext.Set<T>().FirstOrDefaultAsync(exp);
        }

        public async Task<T> GetOneByIDAsync(Guid id)
        {
            return await mctsContext.Set<T>().FirstOrDefaultAsync(x => x.ID.Equals(id));
        }

        public void Update(T entity)
        {
            mctsContext.Set<T>().Update(entity);
        }
    }
}
