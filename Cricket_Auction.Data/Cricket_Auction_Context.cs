using Cricket_Auction.Entities;
using System.Data.Entity;


namespace Cricket_Auction.Data
{
    public class Cricket_Auction_Context : DbContext
    {
        public Cricket_Auction_Context() : base("name=CricketAuctionConnectionString")
        {
        }

        public DbSet<Trophy> Trophies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<AuctionPicture> AuctionPictures { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<AccountAccess> Account { get; set; }
        public DbSet<TeamOwner> TeamOwner { get; set; }

    }
}
