using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Auction.Entities
{
    public class Trophy : BaseEntity
    {
        public string TrophyName { get; set; }
        public string TrophyDescription{ get; set; }
        public virtual List<Players> players { get; set; }
    }


}
