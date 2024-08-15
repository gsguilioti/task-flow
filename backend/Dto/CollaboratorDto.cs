using System.ComponentModel.DataAnnotations;
using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class CollaboratorDto
    {
        public string Name { get; set; }
        [Required]
        public string UserName {  get; set; }
    }
}