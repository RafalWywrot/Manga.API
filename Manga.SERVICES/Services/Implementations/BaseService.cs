using Manga.DATA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.SERVICES.Services.Implementations
{
    public class BaseService
    {
        protected MangaDbContext context;
        public BaseService() : this(new MangaDbContext()) {}

        public BaseService(MangaDbContext Context)
        {
            context = Context;
        }
        protected void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
