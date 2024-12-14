using Cricket_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cricket_Auction.Web.ViewModels
{
    public class TrophiesListingViewModel : PageViewModel
    {
        public List<Trophy> Trophies { get; set; }
    }

    public class TrophiesViewModel : PageViewModel
    {
        public List<Trophy> AllTrophies{ get; set; }
    }

    public class TrophyDetailsViewModel : PageViewModel
    {
        public Trophy trophy { get; set; }
    }

    public class TrophyViewModel : PageViewModel
    {
        public int ID { get; set; }
        public string TrophyName { get; set; }
        public string TrophyDescription { get; set; }
        public List<Players> players { get; set; }

    }

}