using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class StatusDto
    {
        public string Id { get; set; }
        public string TaskStatus { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
