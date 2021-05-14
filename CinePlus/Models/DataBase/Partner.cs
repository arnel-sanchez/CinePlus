using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Partner
    {
        public string Id { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public string Code { get; set; }

        public long Points { get; set; }
    }
}
