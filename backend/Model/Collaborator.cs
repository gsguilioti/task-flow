using TaskFlow.Dto;
using TaskFlow.Model;

namespace TaskFlow.Model
{
    public class Collaborator
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public DateTime? CreatedAt { get; set; }    
        public DateTime? UpdatedAt { get; set; }    

        public User User {get; set; }

        public Collaborator() { }
        public Collaborator(CollaboratorDto dto, User user) 
        {
            Name = dto.Name;
            User = user;
        }

        public void MapDto(UpdateCollaboratorDto dto)
        {
            Name = dto.Name;
        }
    }
}