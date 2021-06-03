﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class UserBoughtArmChair
    {
        public string UserBoughtArmChairId { get; set; }

        public ArmChairByRoom ArmChairByRoom { get; set; }

        public string ArmChairByRoomId { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public Show Show { get; set; }

        public string ShowId { get; set; }
    }
}
