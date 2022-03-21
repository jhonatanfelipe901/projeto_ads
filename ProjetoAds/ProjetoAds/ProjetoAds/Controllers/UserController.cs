using Microsoft.AspNetCore.Mvc;
using ProjetoAds.Application.Contracts;
using ProjetoAds.Application.DTO.Request.Auth;
using ProjetoAds.Domain.Entities;

namespace ProjetoAds.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        //DATA ANOTATION
        [HttpGet]
        [Route("{id:long}")]
        public async Task<User> GetUserById(long id)
        {
            var usuarios = await _userApplication.GetUserById(id);

            return usuarios;
        }
    }
}
