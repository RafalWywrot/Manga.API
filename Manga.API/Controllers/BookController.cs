using Manga.DATA.DAL;
using Manga.DATA.Dto;
using Manga.SERVICES.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Manga.API.Controllers
{
    //[Route("api/Book")]
    public class BookController : ApiController
    {
        private IBookService bookService;
        public BookController(IBookService BookService)
        {
            bookService = BookService;
        }
        [HttpGet]
        public IHttpActionResult Add()
        {
            Image img = Image.FromFile("D:\\Projects\\Manga\\Manga.API\\Manga.API\\images\\BlackCover\\Chapter1\\01.png");
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            bookService.AddBook(ms.ToArray());
            return Ok(); 
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(Guid bookId)
        {
            var bookForDisplay = await bookService.GetBookAsync(bookId);
            if (bookForDisplay == null)
            {
                return BadRequest();
            }
            return Ok(bookForDisplay);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var books = bookService.GetBooksAsync();
            return Ok(books);
        }

        //[HttpPost]
        //public async Task<IHttpActionResult> Post([FromBody] BookForCreation bookForCreation)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

            //    var bookForDisplay = await bookService.AddBookAsync(bookForCreation);
            //    if (bookForCreation == null)
            //    {
            //        return StatusCode(500, "Fail with saving data");
            //    }

            //    return Ok(bookForDisplay);

            //}

        }
}