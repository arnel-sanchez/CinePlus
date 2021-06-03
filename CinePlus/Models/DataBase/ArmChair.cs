using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public enum StateArmChair { ready, broken, sold}

    public class ArmChair
    {
        public string ArmChairId { get; set; }

        public string No { get; set; }

        public StateArmChair StateArmChair { get; set; }
    }
}
