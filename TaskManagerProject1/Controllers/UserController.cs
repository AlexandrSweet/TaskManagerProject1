using BusinessLogic.Models;
using BusinessLogic.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerProject1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost]
        public ActionResult<string> AddUser(UserDto user)
        {
            if (user.Email != null)
            {
                return _userService.AddUser(user);
            }
            return BadRequest("Dont try to add an invalid data !!!");
        }

    }
}
