using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Pay
    {
        [Required]
        [DataType(DataType.Text)]
        public string PayId { get; set; }

        public PayCart PayCart { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string PayCartId { get; set; }

        public UserBoughtArmChair UserBoughtArmChair { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserBougthArmChairId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string DiscountId { get; set; }

        public Discount Discount { get; set; }
    }
}
