using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class ListBilboardResult
    {
        public string Title { get; set; }

        public string Date { get; set; }

        public List<DiscountsByShow> DiscountsByShows { get; set; }
    }
}
