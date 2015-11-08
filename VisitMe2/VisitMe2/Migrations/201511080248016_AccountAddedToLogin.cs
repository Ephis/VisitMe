namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountAddedToLogin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cards", "Account_id", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "login_id", "dbo.Logins");
            DropIndex("dbo.Accounts", new[] { "login_id" });
            DropIndex("dbo.Cards", new[] { "Account_id" });
            DropColumn("dbo.Accounts", "login_id");
            DropColumn("dbo.Cards", "Account_id");
            DropTable("dbo.Logins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        email = c.String(maxLength: 100),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Cards", "Account_id", c => c.Int());
            AddColumn("dbo.Accounts", "login_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cards", "Account_id");
            CreateIndex("dbo.Accounts", "login_id");
            AddForeignKey("dbo.Accounts", "login_id", "dbo.Logins", "id", cascadeDelete: true);
            AddForeignKey("dbo.Cards", "Account_id", "dbo.Accounts", "id");
        }
    }
}
