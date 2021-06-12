using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Top10Model
    {
        public List<MovieOnTop10> MovieOnTop10 { get; set; }

        public Top10 Top10 { get; set; }

        public List<Top10> Top10s { get; set; }

        public List<Movie> MoviesNotAssigned { get; set; }
    }
}
