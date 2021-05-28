using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Movie
    {
        public string MovieId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Director { get; set; }

        public DateTime DateUpload { get; set; }
        
        public MovieType MovieType { get; set; }

        public string MovieTypeId { get; set; }
    }
}
