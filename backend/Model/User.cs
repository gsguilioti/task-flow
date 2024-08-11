using Microsoft.AspNetCore.Identity;

namespace TaskFlow.Model
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Nome {get; set; }
    }
}