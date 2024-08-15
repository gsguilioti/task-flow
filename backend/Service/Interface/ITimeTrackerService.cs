using TaskFlow.Dto;
using TaskFlow.Model;

namespace backend.Service.Interface
{
    public interface ITimeTrackerService
    {
        TimeTracker CreateTimeTracker(TimeTrackerDto dto);
    }
}
