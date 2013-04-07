namespace verk5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentAddedToLecture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Commenter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Commenter");
        }
    }
}
