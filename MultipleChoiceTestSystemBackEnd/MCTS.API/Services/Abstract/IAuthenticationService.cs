using MCTS.API.Objects.Mappers.Dtos;
using System.Threading.Tasks;

namespace MCTS.API.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<AdminHomeDTO> AuthenticateAsync(string username, string password, string secretKey);
    }
}
