using Manga.DATA.DAL;
using Manga.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.SERVICES.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookForDisplay> GetBookAsync(Guid bookId);
        //Task<IList<BookForDisplay>> GetBooksAsync();
        IList<BookForDisplay> GetBooksAsync();
        Task<BookForDisplay> AddBookAsync(BookForCreation bookForCreation);
        void AddBook(byte[] image);
    }
}
