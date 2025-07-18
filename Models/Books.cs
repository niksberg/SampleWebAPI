namespace FirstAPI.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int YearPublished { get; set; }

    }
}
