using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Pay
    {
        public string PayId { get; set; }

        public User User { get; set; }

        public string CardHash { get; set; }

        public UserBoughtArmChair UserBoughtArmChair { get; set; }

        public string UserBougthArmChairId { get; set; }

        public string DiscountById { get; set; }

        public string IdentifierDay { get; set; }
    }
}
