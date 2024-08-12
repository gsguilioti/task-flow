using TaskFlow.Dto;

namespace TaskFlow.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public DateTime? CreatedAt { get; set; }    
        public DateTime? UpdatedAt { get; set; }    
        public DateTime? DeletedAt { get; set; }  

        ICollection<Task> Tasks {get; set; }

        public Project() { }
        public Project(ProjectDto dto)
        {
            Name = dto.Name;
            CreatedAt = dto.CreatedAt;
            UpdatedAt = dto.UpdatedAt;
            DeletedAt = dto.DeletedAt;
        }

        public void MapDto(ProjectDto dto)
        {
            Name = dto.Name;
            CreatedAt = dto.CreatedAt;
            UpdatedAt = dto.UpdatedAt;
            DeletedAt = dto.DeletedAt;
        }
    }
}