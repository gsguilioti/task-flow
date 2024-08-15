using backend.Repository.Interface;
using backend.Service.Interface;
using TaskFlow.Dto;
using TaskFlow.Model;

namespace backend.Service
{
    public class TimeTrackerService : ITimeTrackerService
    {
        private readonly ITimeTrackerRepository _timeTrackerRepository;
        public TimeTrackerService(ITimeTrackerRepository timeTrackerRepository)
        {
            _timeTrackerRepository = timeTrackerRepository;
        }
        public TimeTracker CreateTimeTracker(TimeTrackerDto dto)
        {
            if (dto.EndDate <= dto.StartDate)
                throw new Exception("Horario invalido");

            var trackers = _timeTrackerRepository.GetAllByTask(dto.TaskId);
            if (trackers.Any(t => (dto.StartDate >= t.StartDate && dto.StartDate <= t.EndDate)))
                throw new Exception("Horario invalido");

            if(((trackers.Sum(t => (t.EndDate - t.StartDate).Value.TotalHours)) + (dto.EndDate - dto.StartDate).Value.TotalHours) >= 24)
                throw new Exception("Horario excedido");

            return new TimeTracker (dto);
        }
    }
}
