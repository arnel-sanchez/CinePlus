using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class AddMovieRequest
    {
        public string MovieTypeId { get; set; }

        public DateTime Date { get; set; }

        public string MovieName { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }
    }
}
