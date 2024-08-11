namespace TaskFlow.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public DateTime? CreatedAt { get; set; }    
        public DateTime? UpdatedAt { get; set; }    
        public DateTime? DeletedAt { get; set; }  

        ICollection<Task> Tasks {get; set; }
    }
}