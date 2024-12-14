using Cricket_Auction.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cricket_Auction.Web.ViewModels
{
    public class AuctionsListingViewModel : PageViewModel
    {
        public List<Auction> Auctions { get; set; }
        public int? CategoryID { get; set; }
        public int? PageNo { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class AuctionsViewModel : PageViewModel
    {
        public List<Auction> AllAuctions { get; set; }
        public List<Auction> PromotedAuctions { get; set; }
    }

    public class AuctionDetailsViewModel : PageViewModel
    {
        public Auction Auction { get; set; }
    }

    public class CreateAuctionViewModel : PageViewModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }

        [Required]
        //[MinLength(15, ErrorMessage ="MiniMum Length should be characters")]
        //[MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(10000, 1000000, ErrorMessage = "Your basic amount must be within 100-1000000")]
        public string ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndingTime { get; set; }
        public string Status { get; set; }
        public string AuctionPictures { get; set; }
        public List<Category> Categories { get; set; }
        public List<AuctionPicture> AuctionPicturesList { get; set; }
    }

   
}