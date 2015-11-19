namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class realCardRequestAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardRequests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        senderId = c.String(),
                        reciverId = c.String(),
                        cardId = c.String(),
                        requestType = c.Int(nullable: false),
                        requestState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CardRequests");
        }
    }
}
