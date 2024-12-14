using Cricket_Auction.Data;
using Cricket_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cricket_Auction.Services
{
    public class TrophiesService
    {
        public List<Trophy> GetAllTrophies()
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            return context.Trophies.ToList();
        }

        public Trophy GetTrophyID(int ID)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            return context.Trophies.Find(ID);
        }

        public Trophy GetTrophyName(String TrophyName)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            return context.Trophies.Find(TrophyName);
        }

        public void SaveTrophy(Trophy trophy)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            context.Trophies.Add(trophy);

            context.SaveChanges();
        }

        public void UpdateTrophy(Trophy trophy)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            context.Entry(trophy).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Deletecategory(Trophy trophy)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            context.Entry(trophy).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}

