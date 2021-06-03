using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class ArmChairByRoom
    {
        public string ArmChairId { get; set; }

        public string RoomId { get; set; }

        public string ArmChairByRoomId { get; set; }

        public ArmChair ArmChair { get; set; }

        public Room Room { get; set; }
    }
}
