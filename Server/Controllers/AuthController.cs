using blamato.Server.Services.AuthService;
using blamato.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blamato.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDTO request)
        {
            var response = await _authService.Login(request.Email, request.Password);
            if (!response.Sucess)
            {
                return BadRequest(response);
            }
            return Ok(response);    

        }


        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> RegisterUser(UserRegister user)
        {
            var response = await _authService.Register(new User { Email = user.Email }, user.Password);

            if (response.Sucess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

    }
}
