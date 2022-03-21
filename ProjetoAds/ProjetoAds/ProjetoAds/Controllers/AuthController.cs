using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAds.Application.Contracts;
using ProjetoAds.Application.DTO.Request.Auth;
using ProjetoAds.Application.DTO.Request.User;
using ProjetoAds.Application.DTO.Response.Auth;
using System.Security.Claims;

namespace ProjetoAds.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly IAuthApplication _authApplication;
        private readonly IUserApplication _userApplication;

        public AuthController(IAuthApplication authApplication, IUserApplication userApplication)
        {
            _authApplication = authApplication;
            _userApplication = userApplication;
        }

        [HttpPost]
        [Route("login")]
        public async Task<AuthResponse> LogIn([FromBody] AuthLogInRequest request)
        {
            var usuarios = await _authApplication.LoginAsync(request);

            return usuarios;
        }

        [Authorize]
        [HttpGet]
        [Route("loggedin")]
        public IActionResult GetUserLoggedIn()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

            return BaseResponse(_userApplication.Get(userId));
        }

        [HttpPost]
        [Route("register")]
        public async Task<AuthResponse> Register([FromBody] UserPostRequest request)
        {
            var usuarios = await _authApplication.RegisterAsync(request);

            return usuarios;
        }
    }
}
