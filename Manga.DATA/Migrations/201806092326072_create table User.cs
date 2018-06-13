namespace Manga.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtableUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Student");
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropPrimaryKey("dbo.Student");
            DropPrimaryKey("dbo.Teacher");
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Student", "userId", c => c.Guid(nullable: false));
            AddColumn("dbo.Subject", "TeacherId", c => c.Int(nullable: false));
            AddColumn("dbo.Teacher", "UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Student", "Id");
            DropColumn("dbo.Teacher", "Id");
            DropColumn("dbo.Grades", "StudentId");
            AddColumn("dbo.Student", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Teacher", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Grades", "StudentId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Student", "Id");
            AddPrimaryKey("dbo.Teacher", "Id");
            CreateIndex("dbo.Grades", "StudentId");
            CreateIndex("dbo.Student", "userId");
            CreateIndex("dbo.Teacher", "UserId");
            CreateIndex("dbo.Subject", "TeacherId");
            AddForeignKey("dbo.Subject", "TeacherId", "dbo.Teacher", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Teacher", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Student", "userId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Grades", "StudentId", "dbo.Student", "Id", cascadeDelete: false);
            DropColumn("dbo.Student", "Name");
            DropColumn("dbo.Student", "Surname");
            DropColumn("dbo.Student", "Email");
            DropColumn("dbo.Teacher", "Name");
            DropColumn("dbo.Teacher", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teacher", "Surname", c => c.String(maxLength: 4000));
            AddColumn("dbo.Teacher", "Name", c => c.String(maxLength: 4000));
            AddColumn("dbo.Student", "Email", c => c.String(maxLength: 4000));
            AddColumn("dbo.Student", "Surname", c => c.String(maxLength: 4000));
            AddColumn("dbo.Student", "Name", c => c.String(maxLength: 4000));
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "userId", "dbo.User");
            DropForeignKey("dbo.Teacher", "UserId", "dbo.User");
            DropForeignKey("dbo.Subject", "TeacherId", "dbo.Teacher");
            DropIndex("dbo.Subject", new[] { "TeacherId" });
            DropIndex("dbo.Teacher", new[] { "UserId" });
            DropIndex("dbo.Student", new[] { "userId" });
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropPrimaryKey("dbo.Teacher");
            DropPrimaryKey("dbo.Student");
            AlterColumn("dbo.Teacher", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Student", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Grades", "StudentId", c => c.Guid(nullable: false));
            DropColumn("dbo.Teacher", "UserId");
            DropColumn("dbo.Subject", "TeacherId");
            DropColumn("dbo.Student", "userId");
            DropTable("dbo.User");
            AddPrimaryKey("dbo.Teacher", "Id");
            AddPrimaryKey("dbo.Student", "Id");
            CreateIndex("dbo.Grades", "StudentId");
            AddForeignKey("dbo.Grades", "StudentId", "dbo.Student", "Id", cascadeDelete: true);
        }
    }
}
