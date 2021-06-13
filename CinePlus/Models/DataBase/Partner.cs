using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Partner
    {
        [Required]
        [DataType(DataType.Text)]
        public string Id { get; set; }

        public User User { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Code { get; set; }

        [Required]
        public double Points { get; set; }
    }
}
