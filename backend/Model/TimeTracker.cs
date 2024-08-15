using TaskFlow.Dto;

namespace TaskFlow.Model
{
    public class TimeTracker
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }    
        public DateTime? EndDate { get; set; }    

        public string TimeZoneId { get; set; }

        public DateTime? CreatedAt { get; set; }    
        public DateTime? UpdatedAt { get; set; }    

        public int TaskId { get; set; }
        public Task Task {get; set; }

        public int CollaboratorId { get; set; }
        public Collaborator Collaborator {get; set; }

        public TimeTracker() { }
        public TimeTracker(TimeTrackerDto dto)
        {
            StartDate = dto.StartDate;
            EndDate = dto.EndDate;
            TimeZoneId = dto.TimeZoneId;
            TaskId = dto.TaskId;
            CollaboratorId = dto.CollaboratorId;
        }

        public void MapDto(TimeTrackerDto dto)
        {
            StartDate = dto.StartDate;
            EndDate = dto.EndDate;
            TimeZoneId = dto.TimeZoneId;
            TaskId = dto.TaskId;
            CollaboratorId = dto.CollaboratorId;
        }
    }
}