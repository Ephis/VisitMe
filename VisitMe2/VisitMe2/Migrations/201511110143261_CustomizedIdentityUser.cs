namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomizedIdentityUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "account_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "account_id");
            AddForeignKey("dbo.AspNetUsers", "account_id", "dbo.Accounts", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "account_id", "dbo.Accounts");
            DropIndex("dbo.AspNetUsers", new[] { "account_id" });
            DropColumn("dbo.AspNetUsers", "account_id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
    }
}
