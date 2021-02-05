namespace _24Hr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "ReplyId", c => c.Int(nullable: false));
            AddColumn("dbo.Post", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "ReplyId");
            CreateIndex("dbo.Post", "CommentId");
            AddForeignKey("dbo.Comment", "ReplyId", "dbo.Reply", "ReplyId", cascadeDelete: true);
            AddForeignKey("dbo.Post", "CommentId", "dbo.Comment", "CommentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "ReplyId", "dbo.Reply");
            DropIndex("dbo.Post", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "ReplyId" });
            DropColumn("dbo.Post", "CommentId");
            DropColumn("dbo.Comment", "ReplyId");
        }
    }
}
