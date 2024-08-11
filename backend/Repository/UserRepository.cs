using TaskFlow.Data;
using TaskFlow.Model;

namespace backend.Repository
{
    public class UserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetById(string id) => _context.Users.FirstOrDefault(t => t.Id == id);

        public IEnumerable<User> GetAll() => _context.Users;

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
