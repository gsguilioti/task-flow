using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ProjectDto() { }
        public ProjectDto(Project project)
        {
            Name = project.Name;
            CreatedAt = project.CreatedAt;
            UpdatedAt = project.UpdatedAt;
            DeletedAt = project.DeletedAt;
        }
    }
}