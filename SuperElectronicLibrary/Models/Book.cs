namespace SuperElectronicLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Tittle { get; set; }
        public DateTime YearOfPublication { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
        public List<Genre> Genres { get; set; } = new List<Genre>();

        public User? CurrentUser { get; set; }
    }
}
