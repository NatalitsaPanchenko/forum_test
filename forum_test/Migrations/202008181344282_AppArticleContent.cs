namespace forum_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppArticleContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Content", c => c.String());
            DropColumn("dbo.Articles", "ArticleText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "ArticleText", c => c.String());
            DropColumn("dbo.Articles", "Content");
        }
    }
}
