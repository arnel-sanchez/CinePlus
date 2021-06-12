using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class GetRoomsResult
    {
        public List<ArmChairByRoom> ArmChairByRooms { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
