using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class GetShowsResult
    {
        public List<Show> Shows { get; set; }

        public DateTime Date { get; set; }

        public List<Movie> Movie { get; set; }

        public List<Room> Room { get; set; }
    }
}
