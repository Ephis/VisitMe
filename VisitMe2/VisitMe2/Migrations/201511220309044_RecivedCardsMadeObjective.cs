namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecivedCardsMadeObjective : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecivedCards", "account_id", c => c.Int(nullable: false));
            AddColumn("dbo.RecivedCards", "card_id", c => c.Int(nullable: false));
            CreateIndex("dbo.RecivedCards", "account_id");
            CreateIndex("dbo.RecivedCards", "card_id");
            AddForeignKey("dbo.RecivedCards", "account_id", "dbo.Accounts", "id", cascadeDelete: true);
            AddForeignKey("dbo.RecivedCards", "card_id", "dbo.Cards", "id", cascadeDelete: true);
            DropColumn("dbo.RecivedCards", "accountId");
            DropColumn("dbo.RecivedCards", "cardId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecivedCards", "cardId", c => c.Int(nullable: false));
            AddColumn("dbo.RecivedCards", "accountId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RecivedCards", "card_id", "dbo.Cards");
            DropForeignKey("dbo.RecivedCards", "account_id", "dbo.Accounts");
            DropIndex("dbo.RecivedCards", new[] { "card_id" });
            DropIndex("dbo.RecivedCards", new[] { "account_id" });
            DropColumn("dbo.RecivedCards", "card_id");
            DropColumn("dbo.RecivedCards", "account_id");
        }
    }
}
