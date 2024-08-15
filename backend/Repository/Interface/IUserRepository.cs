using Microsoft.EntityFrameworkCore;
using TaskFlow.Model;

namespace backend.Repository.Interface
{
    public interface IUserRepository
    {
        User GetById(string id);
        User GetByUsername(string username);
        IEnumerable<User> GetAll();
        void Delete(User user);
    }
}
