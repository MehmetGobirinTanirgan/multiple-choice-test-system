using MCTS.Core.CoreEntites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MCTS.Core.RepositoryAbstractions
{
    public interface IBaseEntityRepository<T> where T: BaseEntity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> GetOneByIDAsync(Guid id);
        Task<T> GetOneByExpressionAsync(Expression<Func<T, bool>> exp);
        IQueryable<T> GetAll();
        IQueryable<T> GetListByExpression(Expression<Func<T, bool>> exp);
    }
}
