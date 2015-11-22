namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeObjectiv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CardRequests", "card_id", c => c.Int());
            AddColumn("dbo.CardRequests", "reciver_id", c => c.Int());
            AddColumn("dbo.CardRequests", "sender_id", c => c.Int());
            AddColumn("dbo.Cards", "owner_id", c => c.Int());
            CreateIndex("dbo.CardRequests", "card_id");
            CreateIndex("dbo.CardRequests", "reciver_id");
            CreateIndex("dbo.CardRequests", "sender_id");
            CreateIndex("dbo.Cards", "owner_id");
            AddForeignKey("dbo.Cards", "owner_id", "dbo.Accounts", "id");
            AddForeignKey("dbo.CardRequests", "card_id", "dbo.Cards", "id");
            AddForeignKey("dbo.CardRequests", "reciver_id", "dbo.Accounts", "id");
            AddForeignKey("dbo.CardRequests", "sender_id", "dbo.Accounts", "id");
            DropColumn("dbo.CardRequests", "senderId");
            DropColumn("dbo.CardRequests", "reciverId");
            DropColumn("dbo.CardRequests", "cardId");
            DropColumn("dbo.Cards", "ownerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cards", "ownerId", c => c.Int(nullable: false));
            AddColumn("dbo.CardRequests", "cardId", c => c.Int(nullable: false));
            AddColumn("dbo.CardRequests", "reciverId", c => c.Int(nullable: false));
            AddColumn("dbo.CardRequests", "senderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CardRequests", "sender_id", "dbo.Accounts");
            DropForeignKey("dbo.CardRequests", "reciver_id", "dbo.Accounts");
            DropForeignKey("dbo.CardRequests", "card_id", "dbo.Cards");
            DropForeignKey("dbo.Cards", "owner_id", "dbo.Accounts");
            DropIndex("dbo.Cards", new[] { "owner_id" });
            DropIndex("dbo.CardRequests", new[] { "sender_id" });
            DropIndex("dbo.CardRequests", new[] { "reciver_id" });
            DropIndex("dbo.CardRequests", new[] { "card_id" });
            DropColumn("dbo.Cards", "owner_id");
            DropColumn("dbo.CardRequests", "sender_id");
            DropColumn("dbo.CardRequests", "reciver_id");
            DropColumn("dbo.CardRequests", "card_id");
        }
    }
}
