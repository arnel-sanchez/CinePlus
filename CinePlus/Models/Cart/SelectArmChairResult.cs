using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class SelectArmChairResult
    {
        public Show Show { get; set; }

        public List<ArmChairByRoom> ArmChairByRooms { get; set; }
    }
}
