using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class ArmChair
    {
        [Required]
        [DataType(DataType.Text)]
        public string ArmChairId { get; set; }

        [Required]
        public int No { get; set; }
    }
}
