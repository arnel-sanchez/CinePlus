using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
