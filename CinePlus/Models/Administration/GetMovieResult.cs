using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class GetMovieResult
    {
        public List<Movie> Movie { get; set; }

        public List<MovieType> MovieType { get; set; }
    }
}
