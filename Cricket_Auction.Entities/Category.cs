using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Auction.Entities
{
   public class Category : BaseEntity
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public double MaxPrice { get; set; }

        public virtual List<Auction> Auctions { get; set; }
    }
}
