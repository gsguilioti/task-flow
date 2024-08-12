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
    public class ProjectController : ControllerBase
    {
        private readonly ProjectRepository _repository;
        public ProjectController(ProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _repository.GetById(id);

            if (project == null)
                return NotFound(new { Message = "Not Found" });

            var projectDto = new ProjectDto(project);
            return Ok(projectDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _repository.GetAll();
            if (projects.ToList().Count == 0)
                return Ok(new { Message = "Nenhum registro encontrado" });

            return Ok(projects);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(ProjectDto dto)
        {
            var project = new Project(dto);
            _repository.Create(project);
            return Created("/projects", project);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProjectDto dto)
        {
            var project = _repository.GetById(id);

            if (project == null)
                return NotFound(new { Message = "Not Found" });

            project.MapDto(dto);
            _repository.Update(project);
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _repository.GetById(id);

            if (project == null)
                return NotFound(new { Message = "Not Found" });

            _repository.Delete(project);
            return NoContent();
        }
    }
}
