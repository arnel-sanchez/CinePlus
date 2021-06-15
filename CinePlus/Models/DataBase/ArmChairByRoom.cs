using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public enum StateArmChair { ready, broken, sold }
   
    public class ArmChairByRoom
    {
        [Required]
        [DataType(DataType.Text)]
        public string ArmChairId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string RoomId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ArmChairByRoomId { get; set; }

        [DataType(DataType.Text)]
        public string ShowId { get; set; }

        public ArmChair ArmChair { get; set; }

        public Room Room { get; set; }

        public Show Show { get; set; }

        [Required]
        public StateArmChair StateArmChair { get; set; }
    }
}
