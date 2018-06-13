namespace Manga.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changerelationshipuserstudentteacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teacher", "UserId", "dbo.User");
            DropForeignKey("dbo.Student", "userId", "dbo.User");
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.User", "Id");
            AddForeignKey("dbo.Student", "userId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Teacher", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teacher", "UserId", "dbo.User");
            DropForeignKey("dbo.Student", "userId", "dbo.User");
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.User", "Id");
            AddForeignKey("dbo.Student", "userId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Teacher", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
