using BusinessLogic.Models;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.UserService
{
    public interface IUserService
    {
        public List<UserDto> GetAllUsers();
        public string AddUser(UserDto userDto);
        public UserDto GetUserById(string id);
    }
}
