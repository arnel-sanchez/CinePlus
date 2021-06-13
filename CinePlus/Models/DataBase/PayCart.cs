using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class PayCart
    {
        [Required]
        [DataType(DataType.Text)]
        public string PayCartId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Required]
        public double PayedMoney { get; set; }

        [Required]
        public double PayedPoints { get; set; }

        public User User { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CardHash { get; set; }
    }
}
