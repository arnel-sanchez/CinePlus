using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class MovieType
    {
        [Required]
        [DataType(DataType.Text)]
        public string MovieTypeId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
