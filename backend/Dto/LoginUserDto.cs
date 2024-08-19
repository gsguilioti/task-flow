using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class LoginUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUserDto() { }
        public LoginUserDto(User user) 
        {
            Email = user.Email;
        }
    }
}