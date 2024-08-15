using System.ComponentModel.DataAnnotations;
using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class CollaboratorDto
    {
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [Required]
        public string UserName {  get; set; }

        public CollaboratorDto() { }
        public CollaboratorDto(Collaborator collaborator)
        {
            Name = collaborator.Name;
            UserName = collaborator.User.UserName;
        }
    }
}