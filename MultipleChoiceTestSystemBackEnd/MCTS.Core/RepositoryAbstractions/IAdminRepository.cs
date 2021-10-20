using MCTS.Core.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MCTS.Core.RepositoryAbstractions
{
    public interface IAdminRepository : IBaseEntityRepository<Admin>
    {
        Task<Admin> GetAdminByExpAsync(Expression<Func<Admin, bool>> exp);
    }
}
