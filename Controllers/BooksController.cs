using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // http://localhost:5000/api/books
    public class BooksController : ControllerBase
    {
        // static private List<Book> books = new List<Book>
        //{
        //    new Book
        //    {
        //     Id = 1,
        //     Title = "Story of Vittu Bhai",
        //     Author = "P Vijeth Shetty",
        //     YearPublished = 2023
        //    },

        //    new Book
        //    {
        //     Id = 2,
        //     Title = "Mugude Abhi",
        //     Author = "Abhishek AB",
        //     YearPublished = 2002
        //    },

        //    new Book
        //    {
        //     Id = 3,
        //     Title = "Love of Pornesh",
        //     Author = "Pranesh Ganesh Shetty",
        //     YearPublished = 2024
        //    },

        //    new Book
        //    {
        //     Id = 4,
        //     Title = "Art of War Transcript",
        //     Author = "Sun Tzu",
        //     YearPublished = 2015
        //    }
        //};

        private readonly FirstAPIContext _context;
        public BooksController(FirstAPIContext context)
        {
                       _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            book.Id = updatedBook.Id;
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
