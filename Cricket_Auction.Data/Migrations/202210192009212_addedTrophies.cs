namespace Cricket_Auction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTrophies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trophies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrophyName = c.String(),
                        TrophyDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Players", "TrophyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Players", "TrophyID");
            AddForeignKey("dbo.Players", "TrophyID", "dbo.Trophies", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TrophyID", "dbo.Trophies");
            DropIndex("dbo.Players", new[] { "TrophyID" });
            DropColumn("dbo.Players", "TrophyID");
            DropTable("dbo.Trophies");
        }
    }
}
