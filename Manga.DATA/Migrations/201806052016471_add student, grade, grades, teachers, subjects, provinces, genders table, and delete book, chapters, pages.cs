namespace Manga.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstudentgradegradesteacherssubjectsprovincesgenderstableanddeletebookchapterspages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chapters", "BookId", "dbo.Books");
            DropForeignKey("dbo.Pages", "ChapterId", "dbo.Chapters");
            DropIndex("dbo.Chapters", new[] { "BookId" });
            DropIndex("dbo.Pages", new[] { "ChapterId" });
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Guid(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 4000),
                        Surname = c.String(maxLength: 4000),
                        City = c.String(maxLength: 4000),
                        CodePostal = c.String(maxLength: 4000),
                        ProvinceId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        Address = c.String(maxLength: 4000),
                        PhoneNumber = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gender", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Province", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 4000),
                        Surname = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Books");
            DropTable("dbo.Chapters");
            DropTable("dbo.Pages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Photo = c.Binary(),
                        ChapterId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                        BookId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateOfCreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Grades", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "ProvinceId", "dbo.Province");
            DropForeignKey("dbo.Student", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.Grades", "GradeId", "dbo.Grade");
            DropIndex("dbo.Student", new[] { "GenderId" });
            DropIndex("dbo.Student", new[] { "ProvinceId" });
            DropIndex("dbo.Grades", new[] { "GradeId" });
            DropIndex("dbo.Grades", new[] { "SubjectId" });
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropTable("dbo.Teacher");
            DropTable("dbo.Subject");
            DropTable("dbo.Province");
            DropTable("dbo.Student");
            DropTable("dbo.Grades");
            DropTable("dbo.Grade");
            DropTable("dbo.Gender");
            CreateIndex("dbo.Pages", "ChapterId");
            CreateIndex("dbo.Chapters", "BookId");
            AddForeignKey("dbo.Pages", "ChapterId", "dbo.Chapters", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Chapters", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
