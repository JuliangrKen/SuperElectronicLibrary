using SuperElectronicLibrary.Models;

namespace SuperElectronicLibrary.Repositories
{
    public class BookRepository
    {
        public List<Book>? GetAll()
        {
            using var db = new AppDbContext();

            return db.Books?.ToList();
        }

        public Book? GetById(int id)
        {
            using var db = new AppDbContext();

            return db.Books?.FirstOrDefault(b => b.Id == id);
        }

        public void Add(params Book[] Book)
        {
            using var db = new AppDbContext();

            db.Books?.AddRange(Book);
            db.SaveChanges();
        }

        public void Remove(params Book[] Book)
        {
            using var db = new AppDbContext();

            db.Books?.RemoveRange(Book);
            db.SaveChanges();
        }

        public void UpdateYearOfPublicationById(int id, DateTime newDate)
        {
            using var db = new AppDbContext();

            var book = db.Books?.FirstOrDefault(b => b.Id == id);

            if (book is null)
                throw new Exception();

            book.YearOfPublication = newDate;

            db.SaveChanges();
        }
    }
}