using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class DiscountsByShow
    {
        public string DiscountsByShowId { get; set; }

        public Discount Discount { get; set; }

        public string DiscountId { get; set; }

        public Show Show { get; set; }

        public string ShowId { get; set; }
    }
}
