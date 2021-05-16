using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class UserBoughtArmChair
    {
        public string UserBoughtArmChairId { get; set; }

        public ArmChair ArmChair { get; set; }

        public string ArmChairId { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public Room Room { get; set; }

        public string RoomId { get; set; }
    }
}
