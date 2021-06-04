using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class ListCartResult
    {
        public List<Cart> Carts { get; set; }

        public double Points { get; set; }

        public double PointsTotals { get; set; }
    }
}
