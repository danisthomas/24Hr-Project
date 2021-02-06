namespace _24Hr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModifiedUtc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reply", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Post", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "ModifiedUtc");
            DropColumn("dbo.Reply", "OwnerId");
        }
    }
}
