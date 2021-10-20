using MCTS.API.Objects.Mappers.Dtos;
using MCTS.API.Services.Abstract;
using MCTS.Core.Models;
using MCTS.Core.RepositoryAbstractions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MCTS.API.Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<AdminHomeDTO> AuthenticateAsync(string username, string password, string secretKey)
        {
            var loggingAdmin = new Admin();

            if (!await unitOfWork.Admins.AnyAsync(x => x.Username.Equals(username) && x.Password.Equals(password)))
            {
                return null;
            }
            else
            {
                loggingAdmin = await unitOfWork.Admins.GetAdminByExpAsync(x => x.Username.Equals(username)
                && x.Password.Equals(password));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim("ID", loggingAdmin.ID.ToString()),
                        new Claim("Fullname", loggingAdmin.Fullname),
                        new Claim("Username",loggingAdmin.Username)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string generatedToken = tokenHandler.WriteToken(token);
            return new AdminHomeDTO()
            {
                ID = loggingAdmin.ID,
                Fullname = loggingAdmin.Fullname,
                Username = loggingAdmin.Username,
                Token = generatedToken,
            };
        }
    }
}
