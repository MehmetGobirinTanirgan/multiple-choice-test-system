using MCTS.API.Services.Abstract;
using MCTS.Core.Models;
using MCTS.Core.RepositoryAbstractions;
using System;
using System.Threading.Tasks;

namespace MCTS.API.Services.Concrete
{
    public class ResultService : IResultService
    {
        private readonly IUnitOfWork unitOfWork;

        public ResultService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> AddResultAsync(Result result)
        {
            await unitOfWork.Results.AddResultAsync(result);
            await unitOfWork.SaveAsync();
            return result;
        }

        public async Task<Result> GetResultAsync(Guid id)
        {
            return await unitOfWork.Results.GetResultAsync(id);
        }
    }
}
