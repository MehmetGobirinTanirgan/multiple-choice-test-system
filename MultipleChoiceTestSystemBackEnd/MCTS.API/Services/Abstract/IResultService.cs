using MCTS.Core.Models;
using System;
using System.Threading.Tasks;

namespace MCTS.API.Services.Abstract
{
    public interface IResultService
    {
        Task<Result> AddResultAsync(Result result);
        Task<Result> GetResultAsync(Guid id);
    }
}
