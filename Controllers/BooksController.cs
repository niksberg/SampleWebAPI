using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        static private List<Book> books = new List<Book>
       {
           new Book
           {
            Id = 1,
            Title = "Story of Vittu Bhai",
            Author = "P Vijeth Shetty",
            YearPublished = 2023
           },

           new Book
           {
            Id = 2,
            Title = "Mugude Abhi",
            Author = "Abhishek AB",
            YearPublished = 2002
           },

           new Book
           {
            Id = 3,
            Title = "Love of Pornesh",
            Author = "Pranesh Ganesh Shetty",
            YearPublished = 2024
           },

           new Book
           {
            Id = 4,
            Title = "Art of War Transcript",
            Author = "Sun Tzu",
            YearPublished = 2015
           }
       };
        [HttpGet]
        public ActionResult<List<Books>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{Id}")]
        public ActionResult<Books> GetBookById(int Id)
        {
            var book = books.FirstOrDefault(x => x.Id == Id);
            if (book == null)
            {
                return NotFound();
            }
 
            return Ok(book);
        }

    }
}
