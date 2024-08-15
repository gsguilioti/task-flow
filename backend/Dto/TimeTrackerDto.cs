using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class TimeTrackerDto
    {
        public DateTime? StartDate { get; set; }    
        public DateTime? EndDate { get; set; }    
        public int TaskId { get; set; }
        public int CollaboratorId { get; set; }
    }
}