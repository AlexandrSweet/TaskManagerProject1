using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string UserRole { get; set; }
        public List<User> User { get; set; }
    }
}
