using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class PayTicketRequest
    {
        public long Card { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public DateTime DateTime { get; set; }
    }
}
