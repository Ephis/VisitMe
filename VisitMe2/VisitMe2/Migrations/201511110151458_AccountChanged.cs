namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "email");
            DropColumn("dbo.Accounts", "apiKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "apiKey", c => c.String(nullable: false));
            AddColumn("dbo.Accounts", "email", c => c.String());
        }
    }
}
