using FirstAPI.Controllers;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace FirstAPI.Data
{
    public class FirstAPIContext : DbContext
    {
        public FirstAPIContext(DbContextOptions<FirstAPIContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
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
                );
        }

        public DbSet<Book> Books { get; set; }

    }
}
