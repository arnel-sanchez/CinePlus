using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class CreateShowRequest
    {
        public string Movie { get; set; }

        public string Room { get; set; }

        public double Price { get; set; }

        public double PriceInPoints { get; set; }

        public DateTime Date { get; set; }
    }
}
