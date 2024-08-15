using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Dto
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public string Description {get; set; }
        public int ProjectId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public GetTaskDto() { }
        public GetTaskDto(TaskFlow.Model.Task task)
        {
            Id = task.Id;
            Name = task.Name;
            Description = task.Description;
            CreatedAt = task.CreatedAt;
            UpdatedAt = task.UpdatedAt;
            ProjectId = task.ProjectId;
        }
    }
}