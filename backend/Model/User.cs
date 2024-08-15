using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using TaskFlow.Dto;

namespace TaskFlow.Model
{
    public class User : IdentityUser
    {
        public User() { }
        public User(UserDto dto)
        {
            UserName = dto.UserName;
        }
    }
}