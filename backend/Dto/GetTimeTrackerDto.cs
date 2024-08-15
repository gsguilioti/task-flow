using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class GetTimeTrackerDto
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }    
        public DateTime? EndDate { get; set; }    
        public int TaskId { get; set; }
        public int CollaboratorId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public GetTimeTrackerDto() { }
        public GetTimeTrackerDto(TimeTracker timeTracker) 
        {
            Id = timeTracker.Id;
            StartDate = timeTracker.StartDate;
            EndDate = timeTracker.EndDate;
            TaskId = timeTracker.TaskId;
            CollaboratorId = timeTracker.CollaboratorId;
        }
    }
}