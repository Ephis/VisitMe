namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fName = c.String(),
                        lName = c.String(),
                        email = c.String(),
                        apiKey = c.String(nullable: false),
                        login_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Logins", t => t.login_id, cascadeDelete: true)
                .Index(t => t.login_id);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fName = c.String(),
                        lName = c.String(),
                        phone = c.String(),
                        fax = c.String(),
                        email = c.String(),
                        company = c.String(),
                        position = c.String(),
                        Account_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Accounts", t => t.Account_id)
                .Index(t => t.Account_id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        email = c.String(),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RecivedCards",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        account_id = c.Int(nullable: false),
                        card_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Accounts", t => t.account_id, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.card_id, cascadeDelete: true)
                .Index(t => t.account_id)
                .Index(t => t.card_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecivedCards", "card_id", "dbo.Cards");
            DropForeignKey("dbo.RecivedCards", "account_id", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "login_id", "dbo.Logins");
            DropForeignKey("dbo.Cards", "Account_id", "dbo.Accounts");
            DropIndex("dbo.RecivedCards", new[] { "card_id" });
            DropIndex("dbo.RecivedCards", new[] { "account_id" });
            DropIndex("dbo.Cards", new[] { "Account_id" });
            DropIndex("dbo.Accounts", new[] { "login_id" });
            DropTable("dbo.RecivedCards");
            DropTable("dbo.Logins");
            DropTable("dbo.Cards");
            DropTable("dbo.Accounts");
        }
    }
}
