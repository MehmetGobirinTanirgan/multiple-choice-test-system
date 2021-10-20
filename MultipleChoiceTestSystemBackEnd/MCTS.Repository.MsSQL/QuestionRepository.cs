using MCTS.Core.Models;
using MCTS.Core.RepositoryAbstractions;
using MCTS.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCTS.Repository.MsSQL
{
    public class QuestionRepository : BaseEntityRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(MctsContext mctsContext) : base(mctsContext)
        {

        }

        public async Task<Question> AddNewQuestionAsync(Question question)
        {
            await AddAsync(question);
            return question;
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await GetAll().Include(x => x.Options).ToListAsync();
        }

        public async Task<List<Question>> GetRandomQuestionsForTestAsync()
        {
            return await GetAll().Include(x => x.Options.OrderBy(y => Guid.NewGuid()).Take(4)).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
        }

        public async Task<Question> GetSingleQuestionAsync(Guid id)
        {
            return await GetListByExpression(x => x.ID.Equals(id)).Include(x => x.Options.OrderBy(x => Guid.NewGuid()).Take(4)).FirstOrDefaultAsync();
        }
    }
}
