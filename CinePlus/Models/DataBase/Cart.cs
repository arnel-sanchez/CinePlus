using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class Cart
    {
        [Required]
        [DataType(DataType.Text)]
        public string CartId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ArmChairId { get; set; }

        public ArmChair ArmChair { get; set; }

        public DiscountsByShow DiscountsByShow { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string DiscountsByShowId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
    }
}
