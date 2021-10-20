using MCTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCTS.Core.RepositoryAbstractions
{
    public interface IOptionRepository : IBaseEntityRepository<Option>
    {
        Task<List<Option>> GetOptionsOfQuestion(Guid id);
        Task AddNewOptionAsync(Option option);
        Task AddNewOptionsAsync(List<Option> options);
    }
}
