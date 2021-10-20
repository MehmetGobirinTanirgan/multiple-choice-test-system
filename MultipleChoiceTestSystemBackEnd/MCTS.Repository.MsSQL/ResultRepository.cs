using MCTS.Core.Models;
using MCTS.Core.RepositoryAbstractions;
using MCTS.DB;
using System;
using System.Threading.Tasks;

namespace MCTS.Repository.MsSQL
{
    public class ResultRepository : BaseEntityRepository<Result>, IResultRepository
    {
        public ResultRepository(MctsContext mctsContext) : base(mctsContext)
        {

        }

        public async Task<Result> AddResultAsync(Result result)
        {
            await AddAsync(result);
            return result;
        }

        public async Task<Result> GetResultAsync(Guid id)
        {
            return await GetOneByIDAsync(id);
        }
    }
}
