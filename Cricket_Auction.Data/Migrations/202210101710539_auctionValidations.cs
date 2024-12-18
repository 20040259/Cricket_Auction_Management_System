﻿namespace Cricket_Auction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auctionValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auctions", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Auctions", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Auctions", "ActualAmount", c => c.String(nullable: false));
            AlterColumn("dbo.Auctions", "StartingTime", c => c.DateTime());
            AlterColumn("dbo.Auctions", "EndingTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auctions", "EndingTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Auctions", "StartingTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Auctions", "ActualAmount", c => c.String());
            AlterColumn("dbo.Auctions", "Description", c => c.String());
            AlterColumn("dbo.Auctions", "Title", c => c.String());
        }
    }
}
