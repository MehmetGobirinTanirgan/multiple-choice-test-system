using System;
using System.Threading.Tasks;

namespace MCTS.Core.RepositoryAbstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
        IAdminRepository Admins { get; }
        IOptionRepository Options { get; }
        IQuestionRepository Questions { get; }
        IResultRepository Results { get; }
    }
}
