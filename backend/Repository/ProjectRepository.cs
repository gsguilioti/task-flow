using TaskFlow.Data;
using TaskFlow.Model;

namespace backend.Repository
{
    public class ProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public Project GetById(int id) => _context.Projects.FirstOrDefault(t => t.Id == id);

        public IEnumerable<Project> GetAll() => _context.Projects;

        public void Create(Project project)
        {
            project.CreatedAt = DateTime.Now;
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void Update(Project project)
        {
            project.UpdatedAt = DateTime.Now;
            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public void Delete(Project project)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}
