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
            Title = "1984",
            Author = "George Orwell",
            YearPublished = 1949
           },

           new Book
           {
            Id = 2,
            Title = "Titanic",
            Author = "Richard Mariana",
            YearPublished = 1999
           },

           new Book
           {
            Id = 3,
            Title = "Gandu",
            Author = "Pooki Vasappa",
            YearPublished = 2022
           },

           new Book
           {
            Id = 4,
            Title = "Art of War Transcript",
            Author = "Sun Tzu",
            YearPublished = 2015
           }
       };

    }
}
