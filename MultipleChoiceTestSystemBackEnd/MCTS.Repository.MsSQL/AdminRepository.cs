using MCTS.Core.Models;
using MCTS.Core.RepositoryAbstractions;
using MCTS.DB;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MCTS.Repository.MsSQL
{
    public class AdminRepository : BaseEntityRepository<Admin>,IAdminRepository
    {
        public AdminRepository(MctsContext mctsContext) : base(mctsContext)
        {

        }

        public async Task<Admin> GetAdminByExpAsync(Expression<Func<Admin, bool>> exp)
        {
            return await GetOneByExpressionAsync(exp);
        }
    }
}
