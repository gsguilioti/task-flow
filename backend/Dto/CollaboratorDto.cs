using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class CollaboratorDto
    {
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string UserId {  get; set; }

        public CollaboratorDto() { }
        public CollaboratorDto(Collaborator collaborator)
        {
            Name = collaborator.Name;
            CreatedAt = collaborator.CreatedAt;
            UpdatedAt = collaborator.UpdatedAt;
            DeletedAt = collaborator.DeletedAt;
            UserId = collaborator.User.Id;
        }
    }
}