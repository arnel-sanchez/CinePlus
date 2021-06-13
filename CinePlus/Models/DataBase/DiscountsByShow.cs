using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class DiscountsByShow
    {
        [Required]
        [DataType(DataType.Text)]
        public string DiscountsByShowId { get; set; }

        public Discount Discount { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string DiscountId { get; set; }

        public Show Show { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ShowId { get; set; }
    }
}
