using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class GetProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public GetProjectDto() { }
        public GetProjectDto(Project project)
        {
            Id = project.Id;
            Name = project.Name;
        }
    }
}