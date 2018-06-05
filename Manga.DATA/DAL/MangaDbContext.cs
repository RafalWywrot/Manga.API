using Manga.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.DAL
{
    public class MangaDbContext : DbContext
    {
        public MangaDbContext() : base("MangaConnection") {}

        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Page> Pages { get; set; }
    }
}
