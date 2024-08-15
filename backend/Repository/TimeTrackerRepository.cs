using TaskFlow.Data;
using TaskFlow.Model;

namespace backend.Repository
{
    public class TimeTrackerRepository
    {
        private readonly DataContext _context;
        public TimeTrackerRepository(DataContext context)
        {
            _context = context;
        }

        public TimeTracker GetById(int id) => _context.TimeTrackers.FirstOrDefault(t => t.Id == id);

        public IEnumerable<TimeTracker> GetAll() => _context.TimeTrackers;
        public IEnumerable<TimeTracker> GetAllByTask(int id) => _context.TimeTrackers.Where(t => t.TaskId == id);

        public void Create(TimeTracker timeTracker)
        {
            timeTracker.CreatedAt = DateTime.Now;
            _context.TimeTrackers.Add(timeTracker);
            _context.SaveChanges();
        }

        public void Update(TimeTracker timeTracker)
        {
            timeTracker.UpdatedAt = DateTime.Now;
            _context.TimeTrackers.Update(timeTracker);
            _context.SaveChanges();
        }

        public void Delete(TimeTracker timeTracker)
        {
            _context.TimeTrackers.Remove(timeTracker);
            _context.SaveChanges();
        }
    }
}
