using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
