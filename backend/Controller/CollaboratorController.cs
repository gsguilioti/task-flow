using backend.Repository;
using backend.Repository.Interface;
using backend.Service;
using backend.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TaskFlow.Dto;
using TaskFlow.Model;

namespace backend.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorRepository _repository;
        private readonly ICollaboratorService _collaboratorService;
        public CollaboratorController(ICollaboratorRepository repository, ICollaboratorService collaboratorService)
        {
            _repository = repository;
            _collaboratorService = collaboratorService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var collaborator = _repository.GetById(id);

            if (collaborator == null)
                return NotFound(new { Message = "Not Found" });

            var collaboratorDto = new CollaboratorDto(collaborator);
            return Ok(collaboratorDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var collaborators = _repository.GetAll();
            if (collaborators.ToList().Count == 0)
                return Ok(new { Message = "Nenhum registro encontrado" });

            return Ok(collaborators);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(CollaboratorDto dto)
        {
            var collaborator = _collaboratorService.CreateCollaborator(dto);

            _repository.Create(collaborator);
            return Created("/collaborators", collaborator);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CollaboratorDto dto)
        {
            var collaborator = _repository.GetById(id);

            if (collaborator == null)
                return NotFound(new { Message = "Not Found" });

            collaborator.MapDto(dto);
            _repository.Update(collaborator);
            return Ok(collaborator);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var collaborator = _repository.GetById(id);

            if (collaborator == null)
                return NotFound(new { Message = "Not Found" });

            _repository.Delete(collaborator);
            return NoContent();
        }
    }
}
