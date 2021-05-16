using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Show
    {
        public string ShowId { get; set; }

        public DateTime DateTime { get; set; }

        public double Price { get; set; }

        public Movie Movie { get; set; }

        public string MovieId { get; set; }

        public Room Room { get; set; }

        public string RoomId { get; set; }

        public UserBoughtArmChair UserBoughtArmChair { get; set; }

        public string UserBoughtArmChairId { get; set; }
    }
}
