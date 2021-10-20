using MCTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCTS.API.Services.Abstract
{
    public interface IQuestionService
    {
        Task<List<Question>> GetAllQuestionsAsync();
        Task<List<Question>> GetQuestionsForTestAsync();
        Task<Question> GetSingleQuestionAsync(Guid id);
        Task<Question> AddNewQuestionAsync(Question question);
    }
}
