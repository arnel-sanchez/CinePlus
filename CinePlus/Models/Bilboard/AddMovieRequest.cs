using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class AddMovieRequest
    {
        [Required]
        [DataType(DataType.Text)]
        public string MovieTypeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string MovieName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Director { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
