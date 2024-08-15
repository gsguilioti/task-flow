using backend.Repository.Interface;
using TaskFlow.Data;
using TaskFlow.Model;

namespace backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetById(string id) => _context.Users.FirstOrDefault(t => t.Id == id);
        public User GetByUsername(string username) => _context.Users.FirstOrDefault(t => t.UserName == username);

        public IEnumerable<User> GetAll() => _context.Users;

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
