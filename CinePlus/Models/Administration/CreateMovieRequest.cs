using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class CreateMovieRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Director { get; set; }

        public string MovieTypeId { get; set; }

        public IFormFile File { get; set; }
    }
}
