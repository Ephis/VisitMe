namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToAcount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "account_id", "dbo.Accounts");
            DropIndex("dbo.AspNetUsers", new[] { "account_id" });
            AddColumn("dbo.Accounts", "userId", c => c.String());
            AddColumn("dbo.AspNetUsers", "firstLogin", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "account_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "account_id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "firstLogin");
            DropColumn("dbo.Accounts", "userId");
            CreateIndex("dbo.AspNetUsers", "account_id");
            AddForeignKey("dbo.AspNetUsers", "account_id", "dbo.Accounts", "id");
        }
    }
}
