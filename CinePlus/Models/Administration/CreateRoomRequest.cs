using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class CreateRoomRequest
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        public int ArmChairs { get; set; }
    }
}
