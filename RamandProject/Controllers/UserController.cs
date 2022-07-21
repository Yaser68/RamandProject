using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RamandProject.Common;
using RamandProject.Model;
using RamandProject.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RamandProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }


        
        [HttpGet("GetUsers")]
        [Authorize]
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
                if (!_userService.Exist(username))
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
                else return Content("User Is Already Exist ");
            }
           
            else return Content("Re-password not match to password ");
        }


        [HttpPost("Login")]
        
        public async Task<AuthResult> Login([FromForm] string username, [FromForm] string password)
        {
           
         
                var passwordHash = PasswordHasher.ComputeHash(password);
                var cursor = _userService.GetByAsync(username,password);

            if (cursor)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var signingKey = _configuration["JwtSigningKey"];
                var jwtkey = Encoding.ASCII.GetBytes(signingKey);

                var expires = DateTime.UtcNow.AddDays(2);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] { new Claim(JwtRegisteredClaimNames.UniqueName, username) }),
                    Claims = new Dictionary<string, object> { [JwtRegisteredClaimNames.UniqueName] = username },
                    Expires = expires,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtkey), SecurityAlgorithms.HmacSha256Signature)
                };

                var jwttoken = tokenHandler.CreateToken(tokenDescriptor);


                return  new AuthResult { Successful = true, Token = tokenHandler.WriteToken(jwttoken), };
            }
            else
            {
                return  new AuthResult { Successful = false };
            }
           
        }
    }
}
