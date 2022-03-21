using ProjetoAds.Application.Contracts;
using ProjetoAds.Application.DTO.Response;
using ProjetoAds.Domain.Entities;
using ProjetoAds.Domain.Repository;
using ProjetoAds.Domain.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _userService;

        public UserApplication(IUserService userService)
        {
            _userService = userService;
        }

        public Task<User> Get(long id)
        {
            var user = _userService.Get(id);

            return user;
        }
    }
}
