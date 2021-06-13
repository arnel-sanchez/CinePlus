using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class MovieOnTop10
    {
        [Required]
        [DataType(DataType.Text)]
        public string MovieOnTop10Id { get; set; }

        public Movie Movie { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string MovieId { get; set; }

        public Top10 Top10 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Top10Id { get; set; }
    }
}
