using Microsoft.EntityFrameworkCore;
using TaskFlow.Model;

namespace backend.Repository.Interface
{
    public interface IProjectRepository
    {
        public Project GetById(int id);
        public IEnumerable<Project> GetAll();
        public void Create(Project project);
        public void Update(Project project);
        public void Delete(Project project);
    }
}
