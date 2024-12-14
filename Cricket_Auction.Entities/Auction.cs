using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cricket_Auction.Entities
{

    public class Auction :BaseEntity
    {

        //public Auction()
        //{
        //    EndingTime = DateTime.Now;
        //    StartingTime = DateTime.Now;
           
        //}

       public virtual Category Category { get; set; }

        //for foreign key
        public int CategoryID { get; set; }

        [Required]
        //[MinLength(15, ErrorMessage ="MiniMum Length should be characters")]
        //[MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(10000,1000000, ErrorMessage ="Your basic amount must be within 100-1000000")]
        public string ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndingTime { get; set; }
        public string Status { get; set; }
        public virtual List<AuctionPicture> AuctionPictures { get; set; }
    }
}
