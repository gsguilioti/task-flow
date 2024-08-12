namespace TaskFlow.Dto
{
    public class TaskDto
    {
        public string Name {get; set; }
        public string Description {get; set; }
        public DateTime? CreatedAt { get; set; }    
        public DateTime? UpdatedAt { get; set; }    
        public DateTime? DeletedAt { get; set; }  

        public int ProjectId { get; set; }

        public TaskDto() { }
        public TaskDto(TaskFlow.Model.Task task)
        {
            Name = task.Name;
            Description = task.Description;
            CreatedAt = task.CreatedAt;
            UpdatedAt = task.UpdatedAt;
            DeletedAt = task.DeletedAt;
            ProjectId = task.ProjectId;
        }
    }
}