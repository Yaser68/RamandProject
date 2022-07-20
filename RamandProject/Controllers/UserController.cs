using Microsoft.AspNetCore.Mvc;
using RamandProject.Common;
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
        public async Task<IActionResult> Register([FromForm] string username, [FromForm] string password, [FromForm] string Re_password)
        {
            if (password == Re_password)
            {
              
                    var passwordHash = PasswordHasher.ComputeHash(password);

                    var user = new User
                    {
                        UserName = username,
                        Password = passwordHash,

                    };

                    await _userService.RegisterAsync(user);
                    return Content("User Added to DataBase ");
                }
           
            else return Content("Re-password not match to password ");
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
        {
           
         
                var passwordHash = PasswordHasher.ComputeHash(password);
                var cursor = _userService.GetByAsync(username,password);

            if (cursor)
            {
                return Content("Ok");
            }
            else
            {
                return Content("Cancel");
            }
           
        }
    }
}
