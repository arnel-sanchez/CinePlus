using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class UserBoughtArmChair
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserBoughtArmChairId { get; set; }

        public ArmChairByRoom ArmChairByRoom { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ArmChairByRoomId { get; set; }

        public User User { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserId { get; set; }

        public Show Show { get; set; }

        public string ShowId { get; set; }
    }
}
