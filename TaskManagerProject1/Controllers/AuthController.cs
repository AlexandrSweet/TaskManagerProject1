using BusinessLogic.Models;
using BusinessLogic.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagerProject1.Models;

namespace TaskManagerProject1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel user)
        {
            if(user == null)
            {
                return BadRequest("Invalid data");
            }
            var listOfAllUsers = new List<UserDto>();
            listOfAllUsers = _userService.GetAllUsers();

            if ((listOfAllUsers.FirstOrDefault(u => u.Email == user.Email) != null) && 
                (listOfAllUsers.FirstOrDefault(u => u.Password == user.Password) != null))
            {
                var role = listOfAllUsers.FirstOrDefault(u => u.Email == user.Email).RoleId.ToString();
                var claim = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
                };


                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44331",
                    audience: "https://localhost:44331",
                    claims: claim,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
