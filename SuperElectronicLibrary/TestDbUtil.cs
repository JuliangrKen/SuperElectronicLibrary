using SuperElectronicLibrary.Models;
using SuperElectronicLibrary.Repositories;

namespace SuperElectronicLibrary
{
    internal static class TestDbUtil
    {
        public static void Invoke()
        {
            var authorRep = new AuthorRepository();
            authorRep.Add(new Author() { Name = "autor1" }, new Author() { Name = "autor2" }, new Author() { Name = "autor3" });

            var bookRep = new BookRepository();
            bookRep.Add(new Book() { Tittle = "book1" }, new Book() { Tittle = "book2" }, new Book() { Tittle = "book3" });

            var userRep = new UserRepository();
            userRep.Add(new User() { Name = "user1" }, new User() { Name = "user1" }, new User() { Name = "user1" });

            using (var db = new AppDbContext())
            {
                var book = db.Books?.First() ?? throw new Exception();
                db.Authors?.First()?.Books?.Add(book);
                db.Users?.First()?.Books?.Add(book);

                db.SaveChanges();
            }

            Console.WriteLine("Done");
        }
    }
}