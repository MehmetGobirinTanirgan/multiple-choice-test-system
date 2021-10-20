using MCTS.API.Objects.Mappers.Dtos;
using MCTS.API.Services.Abstract;
using MCTS.API.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MCTS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IConfiguration configuration;

        public AdminController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            this.authenticationService = authenticationService;
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AdminLoginDTO adminLoginDTO)
        {
            if (ModelState.IsValid)
            {
                var appSettingsSection = configuration.GetSection("AppSettings");
                var appSettings = appSettingsSection.Get<AppSettings>();
                var adminHomeDTO = await authenticationService.AuthenticateAsync(adminLoginDTO.Username, adminLoginDTO.Password,
                    appSettings.SecretKey);

                if (adminHomeDTO != null)
                {
                    return Ok(adminHomeDTO);
                }
            }
            return BadRequest();
        }
    }
}
