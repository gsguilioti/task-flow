using System.ComponentModel.DataAnnotations;
using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class GetCollaboratorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User {  get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public GetCollaboratorDto() { }
        public GetCollaboratorDto(Collaborator collaborator)
        {
            Id = collaborator.Id;
            Name = collaborator.Name;
            User = collaborator.User?.UserName;
            CreatedAt = collaborator.CreatedAt;
            UpdatedAt = collaborator.UpdatedAt;
        }
    }
}