namespace Manga.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationshipmanytomanyteachersubject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subject", "TeacherId", "dbo.Teacher");
            DropIndex("dbo.Subject", new[] { "TeacherId" });
            CreateTable(
                "dbo.Linq_Teacher_Subject",
                c => new
                    {
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherId, t.SubjectId })
                .ForeignKey("dbo.Teacher", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            DropColumn("dbo.Subject", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subject", "TeacherId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Linq_Teacher_Subject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Linq_Teacher_Subject", "TeacherId", "dbo.Teacher");
            DropIndex("dbo.Linq_Teacher_Subject", new[] { "SubjectId" });
            DropIndex("dbo.Linq_Teacher_Subject", new[] { "TeacherId" });
            DropTable("dbo.Linq_Teacher_Subject");
            CreateIndex("dbo.Subject", "TeacherId");
            AddForeignKey("dbo.Subject", "TeacherId", "dbo.Teacher", "Id", cascadeDelete: true);
        }
    }
}
