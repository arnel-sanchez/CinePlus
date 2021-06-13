using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Show
    {
        [Required]
        [DataType(DataType.Text)]
        public string ShowId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double PriceInPoints { get; set; }

        public Movie Movie { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string MovieId { get; set; }

        public Room Room { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string RoomId { get; set; }
    }
}
