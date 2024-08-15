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
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _repository.GetById(id);

            if (task == null)
                return NotFound(new { Message = "Not Found" });

            var taskDto = new GetTaskDto(task);
            return Ok(taskDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _repository.GetAll();
            if (tasks.ToList().Count == 0)
                return Ok(new { Message = "Nenhum registro encontrado" });

            return Ok(tasks.Select(t => new GetTaskDto(t)));
        }

        [HttpGet("/task/project/{id}")]
        public IActionResult GetAllByProject(int id)
        {
            var tasks = _repository.GetAllByProject(id);
            if (tasks.ToList().Count == 0)
                return Ok(new { Message = "Nenhum registro encontrado" });

            return Ok(tasks.Select(t => new GetTaskDto(t)));
        }

        [HttpPost]
        public IActionResult Create(TaskDto dto)
        {
            var task = new TaskFlow.Model.Task(dto);
            _repository.Create(task);
            return Created("/tasks", task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskDto dto)
        {
            var task = _repository.GetById(id);

            if (task == null)
                return NotFound(new { Message = "Not Found" });

            task.MapDto(dto);
            _repository.Update(task);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _repository.GetById(id);

            if (task == null)
                return NotFound(new { Message = "Not Found" });

            _repository.Delete(task);
            return NoContent();
        }
    }
}
