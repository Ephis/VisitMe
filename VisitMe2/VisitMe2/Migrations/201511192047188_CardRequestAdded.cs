namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardRequestAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "accountState", c => c.Int(nullable: false));
            AddColumn("dbo.Cards", "cardState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "cardState");
            DropColumn("dbo.Accounts", "accountState");
        }
    }
}
