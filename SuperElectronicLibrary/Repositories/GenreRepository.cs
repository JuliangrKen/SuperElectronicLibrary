using SuperElectronicLibrary.Models;

namespace SuperElectronicLibrary.Repositories
{
    public class GenreRepository
    {
        public void Add(params Genre[] genres)
        {
            using var db = new AppDbContext();

            db.Genres?.AddRange(genres);
            db.SaveChanges();
        }

        public Genre? GetById(int id)
        {
            using var db = new AppDbContext();

            return db.Genres?.FirstOrDefault(b => b.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"> Вызывается, если не найден жанр </exception>
        public int GetNumBooksByAuthorId(int id)
        {
            using var db = new AppDbContext();

            var genre = db.Genres?.FirstOrDefault(b => b.Id == id);

            if (genre == null)
                throw new ArgumentException();

            return genre.Books.Count();
        }
    }
}