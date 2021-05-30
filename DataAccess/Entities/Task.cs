using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StatusId { get; set; }
        public string UserId { get; set; }



    }
}
