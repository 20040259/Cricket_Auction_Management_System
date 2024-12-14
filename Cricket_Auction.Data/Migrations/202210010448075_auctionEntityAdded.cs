namespace Cricket_Auction.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class auctionEntityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    PictureURL = c.String(),
                    Description = c.String(),
                    ActualAmount = c.String(),
                    StartingTime = c.DateTime(nullable: false),
                    EndingTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.Auctions");
        }
    }
}
