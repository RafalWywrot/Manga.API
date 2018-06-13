namespace Manga.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addteacheridtotablegrades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Grades", "TeacherId");
            AddForeignKey("dbo.Grades", "TeacherId", "dbo.Teacher", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "TeacherId", "dbo.Teacher");
            DropIndex("dbo.Grades", new[] { "TeacherId" });
            DropColumn("dbo.Grades", "TeacherId");
        }
    }
}
