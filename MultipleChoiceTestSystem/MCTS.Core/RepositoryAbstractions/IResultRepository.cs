using MCTS.Core.Models;
using System;
using System.Threading.Tasks;

namespace MCTS.Core.RepositoryAbstractions
{
    public interface IResultRepository : IBaseEntityRepository<Result>
    {
        Task<Result> AddResultAsync(Result result);
        Task<Result> GetResultAsync(Guid id);
    }
}
