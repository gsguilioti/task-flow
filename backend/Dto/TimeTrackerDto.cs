using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class TimeTrackerDto
    {
        public DateTime? StartDate { get; set; }    
        public DateTime? EndDate { get; set; }    

        public string TimeZoneId { get; set; }


        public int TaskId { get; set; }

        public int CollaboratorId { get; set; }
        public TimeTrackerDto() { }
        public TimeTrackerDto(TimeTracker timeTracker) 
        {
            StartDate = timeTracker.StartDate;
            EndDate = timeTracker.EndDate;
            TimeZoneId = timeTracker.TimeZoneId;
            TaskId = timeTracker.TaskId;
            CollaboratorId = timeTracker.CollaboratorId;
        }
    }
}