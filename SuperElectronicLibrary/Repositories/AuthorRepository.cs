using SuperElectronicLibrary;
using SuperElectronicLibrary.Models;

public class AuthorRepository
{
    public void Add(params Author[] authors)
    {
        using var db = new AppDbContext();

        db.Authors?.AddRange(authors);
        db.SaveChanges();
    }

    public Author? GetById(int id)
    {
        using var db = new AppDbContext();

        return db.Authors?.FirstOrDefault(b => b.Id == id);
    }
}