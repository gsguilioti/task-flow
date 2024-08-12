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
        public DateTime? DeletedAt { get; set; }  

        public User User {get; set; }

        public Collaborator() { }
        public Collaborator(CollaboratorDto dto) 
        {
            Name = dto.Name;
            CreatedAt = dto.CreatedAt;
            UpdatedAt = dto.UpdatedAt;
            DeletedAt = dto.DeletedAt;
            // todo user
        }

        public void MapDto(CollaboratorDto dto)
        {
            Name = dto.Name;
            CreatedAt = dto.CreatedAt;
            UpdatedAt = dto.UpdatedAt;
            DeletedAt = dto.DeletedAt;
            // todo user
        }
    }
}