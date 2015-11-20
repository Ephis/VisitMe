namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdsAsInts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CardRequests", "senderId", c => c.Int(nullable: false));
            AlterColumn("dbo.CardRequests", "reciverId", c => c.Int(nullable: false));
            AlterColumn("dbo.CardRequests", "cardId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CardRequests", "cardId", c => c.String());
            AlterColumn("dbo.CardRequests", "reciverId", c => c.String());
            AlterColumn("dbo.CardRequests", "senderId", c => c.String());
        }
    }
}
