namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginSystemTryedAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "email", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "email", c => c.String());
        }
    }
}
