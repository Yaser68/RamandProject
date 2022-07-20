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

        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            var result= await _userService.GetUsersAsync();
            return result;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromForm] string username, [FromForm] string password, [FromForm] string Re_password)
        {
            if (password == Re_password)
            {
               return View();
            }
            else return Content("Re-password not match to password ");
        }
    }
}
