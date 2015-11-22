namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecivedCardChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecivedCards", "account_id", "dbo.Accounts");
            DropForeignKey("dbo.RecivedCards", "card_id", "dbo.Cards");
            DropIndex("dbo.RecivedCards", new[] { "account_id" });
            DropIndex("dbo.RecivedCards", new[] { "card_id" });
            AddColumn("dbo.RecivedCards", "accountId", c => c.Int(nullable: false));
            AddColumn("dbo.RecivedCards", "cardId", c => c.Int(nullable: false));
            DropColumn("dbo.RecivedCards", "account_id");
            DropColumn("dbo.RecivedCards", "card_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecivedCards", "card_id", c => c.Int(nullable: false));
            AddColumn("dbo.RecivedCards", "account_id", c => c.Int(nullable: false));
            DropColumn("dbo.RecivedCards", "cardId");
            DropColumn("dbo.RecivedCards", "accountId");
            CreateIndex("dbo.RecivedCards", "card_id");
            CreateIndex("dbo.RecivedCards", "account_id");
            AddForeignKey("dbo.RecivedCards", "card_id", "dbo.Cards", "id", cascadeDelete: true);
            AddForeignKey("dbo.RecivedCards", "account_id", "dbo.Accounts", "id", cascadeDelete: true);
        }
    }
}
