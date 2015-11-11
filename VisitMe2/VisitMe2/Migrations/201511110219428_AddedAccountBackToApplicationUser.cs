namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAccountBackToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "account_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "account_id");
            AddForeignKey("dbo.AspNetUsers", "account_id", "dbo.Accounts", "id");
            DropColumn("dbo.AspNetUsers", "fName");
            DropColumn("dbo.AspNetUsers", "lName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "lName", c => c.String());
            AddColumn("dbo.AspNetUsers", "fName", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "account_id", "dbo.Accounts");
            DropIndex("dbo.AspNetUsers", new[] { "account_id" });
            DropColumn("dbo.AspNetUsers", "account_id");
        }
    }
}
