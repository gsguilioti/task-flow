using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class UserDto
    {
        public string UserName { get; set; }

        public UserDto() { }
        public UserDto(User user) 
        { 
            UserName = user.UserName;
        }
    }
}