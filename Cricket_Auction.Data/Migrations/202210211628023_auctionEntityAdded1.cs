namespace Cricket_Auction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auctionEntityAdded1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "Status");
        }
    }
}
