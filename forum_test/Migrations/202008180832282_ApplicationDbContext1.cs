namespace forum_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationDbContext1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "UserId", c => c.String());
            AlterColumn("dbo.Topics", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Topics", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Articles", "UserId", c => c.Int(nullable: false));
        }
    }
}
