namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedAccountFromIdentityUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "account_id", "dbo.Accounts");
            DropIndex("dbo.AspNetUsers", new[] { "account_id" });
            AddColumn("dbo.AspNetUsers", "fName", c => c.String());
            AddColumn("dbo.AspNetUsers", "lName", c => c.String());
            DropColumn("dbo.AspNetUsers", "account_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "account_id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "lName");
            DropColumn("dbo.AspNetUsers", "fName");
            CreateIndex("dbo.AspNetUsers", "account_id");
            AddForeignKey("dbo.AspNetUsers", "account_id", "dbo.Accounts", "id");
        }
    }
}
