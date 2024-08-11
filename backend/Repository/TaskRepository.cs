using TaskFlow.Data;
using TaskFlow.Model;

namespace backend.Repository
{
    public class TaskRepository
    {
        private readonly DataContext _context;
        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public TaskFlow.Model.Task GetById(int id) => _context.Tasks.FirstOrDefault(t => t.Id == id);

        public IEnumerable<TaskFlow.Model.Task> GetAll() => _context.Tasks;

        public void Create(TaskFlow.Model.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(TaskFlow.Model.Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void Delete(TaskFlow.Model.Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
