using Microsoft.AspNetCore.Mvc;
using RamandProject.Model;
using RamandProject.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RamandProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            var result= await _userService.GetUsersAsync();
            return result;
        }
    }
}
