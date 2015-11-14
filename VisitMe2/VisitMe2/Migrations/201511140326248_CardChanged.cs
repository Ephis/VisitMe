namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "ownerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "ownerId");
        }
    }
}
