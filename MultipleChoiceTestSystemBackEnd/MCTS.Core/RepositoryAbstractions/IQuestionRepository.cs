using MCTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCTS.Core.RepositoryAbstractions
{
    public interface IQuestionRepository : IBaseEntityRepository<Question>
    {
        Task<List<Question>> GetAllQuestionsAsync();
        Task<List<Question>> GetRandomQuestionsForTestAsync();
        Task<Question> GetSingleQuestionAsync(Guid id);
        Task<Question> AddNewQuestionAsync(Question question);
            
    }
}
