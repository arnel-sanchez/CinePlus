using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class PayCart
    {
        public string PayCartId { get; set; }

        public DateTime DateTime { get; set; }

        public double Payed { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public string CardHash { get; set; }
    }
}
