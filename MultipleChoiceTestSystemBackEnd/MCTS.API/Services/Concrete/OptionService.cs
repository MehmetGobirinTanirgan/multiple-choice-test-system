using MCTS.API.Services.Abstract;
using MCTS.Core.Models;
using MCTS.Core.RepositoryAbstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCTS.API.Services.Concrete
{
    public class OptionService : IOptionService
    {
        private readonly IUnitOfWork unitOfWork;

        public OptionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddNewOptionAsync(Option option)
        {
            await unitOfWork.Options.AddNewOptionAsync(option);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<Option>> GetOptionsOfQuestion(Guid id)
        {
            return await unitOfWork.Options.GetOptionsOfQuestion(id);
        }
    }
}
