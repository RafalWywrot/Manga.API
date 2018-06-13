using Manga.SERVICES.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.SERVICES.Services.Implementations
{
    public class UserService : BaseService, IUserService
    {
        public void removeUser(Guid id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
            SaveChanges();
        }
    }
}
