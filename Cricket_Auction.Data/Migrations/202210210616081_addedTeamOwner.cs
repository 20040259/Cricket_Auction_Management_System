﻿namespace Cricket_Auction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTeamOwner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamOwners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeamOwners");
        }
    }
}
