using TaskFlow.Dto;

namespace TaskFlow.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public string Description {get; set; }
        public DateTime? CreatedAt { get; set; }    
        public DateTime? UpdatedAt { get; set; }    
        public DateTime? DeletedAt { get; set; }  

        public int ProjectId { get; set; }
        public Project Project {get; set; }

        ICollection<TimeTracker> TimeTrackers {get; set; }

        public Task() { }
        public Task(TaskDto dto)
        {
            Name = dto.Name;
            Description = dto.Description;
            ProjectId = dto.ProjectId;
        }

        public void MapDto(TaskDto dto)
        {
            Name = dto.Name;
            Description = dto.Description;
            ProjectId = dto.ProjectId;
        }
    }
}