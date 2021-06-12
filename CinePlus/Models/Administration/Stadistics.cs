using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Stadistics
    {
        public List<Movie> Movies { get; set; }

        public List<MovieType> MovieTypes { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }
    }
}
