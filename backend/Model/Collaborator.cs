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
    }
}