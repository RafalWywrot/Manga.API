namespace Manga.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateOfCreation = c.DateTime(nullable: false),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Photo = c.Binary(),
                        ChapterId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chapters", t => t.ChapterId, cascadeDelete: true)
                .Index(t => t.ChapterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "ChapterId", "dbo.Chapters");
            DropForeignKey("dbo.Chapters", "BookId", "dbo.Books");
            DropIndex("dbo.Pages", new[] { "ChapterId" });
            DropIndex("dbo.Chapters", new[] { "BookId" });
            DropTable("dbo.Pages");
            DropTable("dbo.Chapters");
            DropTable("dbo.Books");
        }
    }
}
