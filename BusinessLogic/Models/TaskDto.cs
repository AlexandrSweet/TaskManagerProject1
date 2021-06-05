using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class TaskDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StatusId { get; set; }
        public string UserId { get; set; }
        public string NameUser { get; set; }

    }
}
