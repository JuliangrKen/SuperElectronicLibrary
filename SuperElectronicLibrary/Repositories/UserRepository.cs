using SuperElectronicLibrary.Models;

namespace SuperElectronicLibrary.Repositories
{
    public class UserRepository
    {
        public List<User>? GetAll()
        {
            using var db = new AppDbContext();

            return db.Users?.ToList();
        }

        public User? GetById(int id)
        {
            using var db = new AppDbContext();

            return db.Users?.FirstOrDefault(u => u.Id == id);
        }

        public void Add(params User[] user)
        {
            using var db = new AppDbContext();

            db.Users?.AddRange(user);
            db.SaveChanges();
        }

        public void Remove(params User[] user)
        {
            using var db = new AppDbContext();

            db.Users?.RemoveRange(user);
            db.SaveChanges();
        }

        public void UpdateNameById(int id, string newName)
        {
            using var db = new AppDbContext();

            var user = db.Users?.FirstOrDefault(b => b.Id == id);

            if (user is null)
                throw new Exception();

            user.Name = newName;
       
            db.SaveChanges();
        }
    }
}