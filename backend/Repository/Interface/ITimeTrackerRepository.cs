using Microsoft.EntityFrameworkCore;
using TaskFlow.Model;

namespace backend.Repository.Interface
{
    public interface ITimeTrackerRepository
    {
        TimeTracker GetById(int id);
        IEnumerable<TimeTracker> GetAll();
        IEnumerable<TimeTracker> GetAllByTask(int id);
        void Create(TimeTracker timeTracker);
        void Update(TimeTracker timeTracker);
        void Delete(TimeTracker timeTracker);
    }
}
