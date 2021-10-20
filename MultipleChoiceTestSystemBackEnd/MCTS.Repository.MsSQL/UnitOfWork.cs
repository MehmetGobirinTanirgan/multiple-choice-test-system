using MCTS.Core.RepositoryAbstractions;
using MCTS.DB;
using System;
using System.Threading.Tasks;

namespace MCTS.Repository.MsSQL
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue = false;
        private readonly MctsContext context;

        public UnitOfWork(MctsContext context)
        {
            this.context = context;
            Admins = new AdminRepository(context);
            Options = new OptionRepository(context);
            Questions = new QuestionRepository(context);
            Results = new ResultRepository(context);
        }

        public IAdminRepository Admins { get; }
        public IOptionRepository Options { get; }
        public IQuestionRepository Questions { get; }
        public IResultRepository Results { get; }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
