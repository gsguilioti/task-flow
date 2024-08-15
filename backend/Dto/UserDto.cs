using TaskFlow.Model;

namespace TaskFlow.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public UserDto() { }
        public UserDto(User user) 
        { 
            Id = user.Id;
            UserName = user.UserName;
        }
    }
}