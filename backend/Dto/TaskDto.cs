using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Dto
{
    public class TaskDto
    {
        public string Name {get; set; }
        public string Description {get; set; }

        [Required]
        public int ProjectId { get; set; }
    }
}