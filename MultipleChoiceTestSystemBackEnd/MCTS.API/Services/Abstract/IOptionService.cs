using MCTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCTS.API.Services.Abstract
{
    public interface IOptionService
    {
        Task AddNewOptionAsync(Option option);
        Task<List<Option>> GetOptionsOfQuestion(Guid id);
    }
}
