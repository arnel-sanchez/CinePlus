using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class EditModelRequest
    {
        public string name { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string userName { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string userId { get; set; }
    }
}
