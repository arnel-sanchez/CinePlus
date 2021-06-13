using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Movie
    {
        [Required]
        [DataType(DataType.Text)]
        public string MovieId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Director { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateUpload { get; set; }
        
        public MovieType MovieType { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string MovieTypeId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string URL { get; set; }
    }
}
