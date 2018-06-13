namespace Manga.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changerelationshipbetweensubjectandstudentmapthemtonewclasslinq_SubjecT_Teacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Linq_Teacher_Subject", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Linq_Teacher_Subject", "SubjectId", "dbo.Subject");
            DropIndex("dbo.Linq_Teacher_Subject", new[] { "TeacherId" });
            DropIndex("dbo.Linq_Teacher_Subject", new[] { "SubjectId" });
            CreateTable(
                "dbo.Linq_Subject_Teacher",
                c => new
                    {
                        SubjectID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectID, t.TeacherID })
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.TeacherID);
            
            DropTable("dbo.Linq_Teacher_Subject");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Linq_Teacher_Subject",
                c => new
                    {
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherId, t.SubjectId });
            
            DropForeignKey("dbo.Linq_Subject_Teacher", "TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.Linq_Subject_Teacher", "SubjectID", "dbo.Subject");
            DropIndex("dbo.Linq_Subject_Teacher", new[] { "TeacherID" });
            DropIndex("dbo.Linq_Subject_Teacher", new[] { "SubjectID" });
            DropTable("dbo.Linq_Subject_Teacher");
            CreateIndex("dbo.Linq_Teacher_Subject", "SubjectId");
            CreateIndex("dbo.Linq_Teacher_Subject", "TeacherId");
            AddForeignKey("dbo.Linq_Teacher_Subject", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Linq_Teacher_Subject", "TeacherId", "dbo.Teacher", "Id", cascadeDelete: true);
        }
    }
}
