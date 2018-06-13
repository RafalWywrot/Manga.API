using Manga.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.DAL
{
    public class MangaDbContext : DbContext
    {
        public MangaDbContext() : base("MangaConnection") {}

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Linq_Subject_Teacher> Subject_Teachers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //DONT DO THIS ANYMORE
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Teacher>()
            //   .HasMany<Subject>(s => s.Subjects)
            //   .WithMany(c => c.Teachers)
            //   .Map(cs =>
            //   {
            //       cs.MapLeftKey("TeacherId");
            //       cs.MapRightKey("SubjectId");
            //       cs.ToTable("Linq_Teacher_Subject");
            //   });
        }
    }

}
