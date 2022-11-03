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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"> Вызывается, если не найден автор </exception>
    public int GetNumBooksByAuthorId(int id)
    {
        using var db = new AppDbContext();

        var author = db.Authors?.FirstOrDefault(b => b.Id == id);

        if (author == null)
            throw new ArgumentException();

        return author.Books.Count();
    }
}