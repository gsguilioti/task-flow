using backend.Repository;
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
        private readonly UserRepository _repository;
        public UserController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var user = _repository.GetById(id);

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

        [HttpPut("{id}")]
        public IActionResult Update(string id, UserDto dto)
        {
            var user = _repository.GetById(id);

            if (user == null)
                return NotFound(new { Message = "Not Found" });

            user.MapDto(dto);
            _repository.Update(user);
            return Ok(user);
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
