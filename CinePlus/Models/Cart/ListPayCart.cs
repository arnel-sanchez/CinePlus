using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class ListPayCart
    {
        public PayCart PayCart { get; set; }

        public List<Pay> Pays {get; set;}
    }
}
