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
    public class OptionRepository : BaseEntityRepository<Option>, IOptionRepository
    {
        public OptionRepository(MctsContext mctsContext) : base(mctsContext)
        {

        }

        public async Task AddNewOptionAsync(Option option)
        {
            await AddAsync(option);
        }

        public async Task AddNewOptionsAsync(List<Option> options)
        {
            await AddRangeAsync(options);
        }

        public async Task<List<Option>> GetOptionsOfQuestion(Guid id)
        {
            return await GetListByExpression(x => x.QuestionID.Equals(id)).OrderBy(x => Guid.NewGuid()).Take(4).ToListAsync();
        }
    }
}
