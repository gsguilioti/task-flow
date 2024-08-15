using backend.Repository;
using backend.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TaskFlow.Dto;
using TaskFlow.Model;

namespace backend.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{username}")]
        public IActionResult GetById(string username)
        {
            var user = _repository.GetByUsername(username);

            if (user == null)
                return NotFound(new { Message = "Not Found" });

            var userDto = new UserDto(user);
            return Ok(userDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _repository.GetAll();
            if (users.ToList().Count == 0)
                return Ok(new { Message = "Nenhum registro encontrado" });

            return Ok(users);
        }

        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            var user = _repository.GetByUsername(username);

            if (user == null)
                return NotFound(new { Message = "Not Found" });

            _repository.Delete(user);
            return NoContent();
        }
    }
}
