using AutoMapper;
using Manga.DATA.DAL;
using Manga.DATA.Dto;
using Manga.DATA.Entities;
using Manga.SERVICES.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.SERVICES.Services.Implementations
{
    public class BookService : IBookService
    {
        private MangaDbContext dbContext;

        public BookService(MangaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public void AddBook(byte[] image)
        //{
        //    //utworz ksiazke
        //    Book book = new Book()
        //    {
                
        //    };
        //    //utworz chapter z id ksiazki
        //    //utworz page
        //    Page page = new Page()
        //    {
        //        ChapterId = new Guid("0cfd5819-dc50-4ae3-bfed-fa61664f6044"),
        //        Id = new Guid("87995340-4c81-4b46-acd3-6e7e44ac9d5a"),
        //        Photo = image
        //    };
        //    dbContext.Pages.Add(page);
        //    dbContext.SaveChanges();
        //}

        //public async Task<BookForDisplay> AddBookAsync(BookForCreation bookForCreation)
        //{
        //    if (await dbContext.SaveChangesAsync() <= 0)
        //    {
        //        return null;
        //    }

        //    var bookForDisplay = Mapper.Map<BookForDisplay>(book);
        //    return bookForDisplay;

        //}


        //public async Task<BookForDisplay> GetBookAsync(Guid bookId)
        //{
        //    var book = await dbContext.Books.FindAsync(bookId);
        //    var bookForDisplay = Mapper.Map<BookForDisplay>(book);
        //    return bookForDisplay;
        //}


        //public IList<BookForDisplay> GetBooksAsync()
        //{
        //    var books = dbContext.Books.ToList();
        //    var booksForDisplay = Mapper.Map<IList<BookForDisplay>>(books);
        //    return booksForDisplay;
        //}
    }
}
