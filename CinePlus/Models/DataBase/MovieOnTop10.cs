using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class MovieOnTop10
    {
        public string MovieOnTop10Id { get; set; }

        public Movie Movie { get; set; }

        public string MovieId { get; set; }

        public Top10 Top10 { get; set; }

        public string Top10Id { get; set; }
    }
}
