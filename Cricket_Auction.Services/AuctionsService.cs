using Cricket_Auction.Data;
using Cricket_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cricket_Auction.Services
{
    public class AuctionsService
    {
       public List<Auction> GetAllAuctions()
        {
             Cricket_Auction_Context context = new Cricket_Auction_Context();

             return context.Auctions.ToList();
        }

        public List<Auction> SearchAuctions(int? categoryID, string searchTerm, int? pageNo, int pageSize)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            var auctions = context.Auctions.AsQueryable();

            if (categoryID.HasValue && categoryID.Value > 0)
            {
                auctions = auctions.Where(x => x.CategoryID == categoryID.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;

            var skipcount = (pageNo.Value - 1) * pageSize;
            //pageNo = pageNo.HasValue ? pageNo.Value : 1;

            return auctions.OrderByDescending(x=>x.CategoryID).Skip(skipcount).Take(pageSize).ToList();
        }

        public int GetAuctionCount(int? categoryID, string searchTerm)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            var auctions = context.Auctions.AsQueryable();

            if (categoryID.HasValue && categoryID.Value > 0)
            {
                auctions = auctions.Where(x => x.CategoryID == categoryID.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            }


            return auctions.Count();
        }

        public List<Auction> GetPromotedAuctions()
        {

            Cricket_Auction_Context context = new Cricket_Auction_Context();

            return context.Auctions.Take(4).ToList();

        }


        public Auction GetAuctionID(int ID)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            return context.Auctions.Find(ID);
        }

        public void SaveAuction(Auction auction)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();
           
                context.Auctions.Add(auction);
                
                context.SaveChanges(); 
        }

         public void UpdateAuction(Auction auction)
         {
             Cricket_Auction_Context context = new Cricket_Auction_Context();

            try
            {
                var exitingAuction = context.Auctions.Find(auction.ID);

                context.AuctionPictures.RemoveRange(exitingAuction.AuctionPictures);

                context.Entry(exitingAuction).CurrentValues.SetValues(auction);

                context.AuctionPictures.AddRange(auction.AuctionPictures);

                context.SaveChanges();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAuction(Auction auction)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            context.Entry(auction).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
