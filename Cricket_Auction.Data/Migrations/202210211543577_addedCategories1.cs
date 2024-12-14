namespace Cricket_Auction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCategories1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "MaxPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "MaxPrice");
        }
    }
}
