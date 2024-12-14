using Cricket_Auction.Data;
using Cricket_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Auction.Services
{
    public class ManagePlayersService
    {
        Cricket_Auction_Context context = new Cricket_Auction_Context();
        //get all players
        public List<Players> GetAllPlayers()
        {
            return context.Players.ToList();
        }

        //search auctions
        //public List<Auction> SearchAuctions(int? categoryID, string searchTerm, int? pageNo, int pageSize)
        //{
        //    Cricket_Auction_Context context = new Cricket_Auction_Context();

        //    var auctions = context.Auctions.AsQueryable();

        //    if (categoryID.HasValue && categoryID.Value > 0)
        //    {
        //        auctions = auctions.Where(x => x.CategoryID == categoryID.Value);
        //    }

        //    if (!string.IsNullOrEmpty(searchTerm))
        //    {
        //        auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
        //    }

        //    pageNo = pageNo ?? 1;

        //    var skipcount = (pageNo.Value - 1) * pageSize;
        //    //pageNo = pageNo.HasValue ? pageNo.Value : 1;

        //    return auctions.OrderByDescending(x => x.CategoryID).Skip(skipcount).Take(pageSize).ToList();
        //}

        //public int GetAuctionCount(int? categoryID, string searchTerm)
        //{
        //    Cricket_Auction_Context context = new Cricket_Auction_Context();

        //    var auctions = context.Auctions.AsQueryable();

        //    if (categoryID.HasValue && categoryID.Value > 0)
        //    {
        //        auctions = auctions.Where(x => x.CategoryID == categoryID.Value);
        //    }

        //    if (!string.IsNullOrEmpty(searchTerm))
        //    {
        //        auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
        //    }


        //    return auctions.Count();
        //}

        //players auctions loading to home page
        //public List<Auction> GetPromotedAuctions()
        //{

        //    Cricket_Auction_Context context = new Cricket_Auction_Context();

        //    return context.Auctions.Take(4).ToList();

        //}

        //get player id
        public Players GetPlayerID(int ID)
        {
            return context.Players.Find(ID);
        }

        public Players GetPlayerUsername(string Username)
        {
            return context.Players.Find(Username);
        }

        //create & save player
        public void SavePlayers(Players players)
        {
          context.Players.Add(players);

            context.SaveChanges();
        }

        //update player details
        public void UpdatePlayers(Players players)
        { 
            //var exitingAuction = context.Players.Find(players.ID);

            ////  context.PlayersPictures.RemoveRange(exitingAuction.PlayerPictures);

            //context.Entry(exitingAuction).CurrentValues.SetValues(players);

            ////context.AuctionPictures.AddRange(players.AuctionPictures);

            //context.SaveChanges();

            context.Entry(players).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        //delete auctions
        public void DeletePlayers(Players players)
        {
            context.Entry(players).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
