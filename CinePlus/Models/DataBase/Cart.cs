using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Cart
    {
        public string CartId { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public Show Show { get; set; }

        public string ShowId { get; set; }

        public string ArmChairId { get; set; }

        public ArmChair ArmChair { get; set; }
    }
}
