using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class CreateShowRequest
    {
        [Required]
        [DataType(DataType.Text)]
        public string Movie { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Room { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double PriceInPoints { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
