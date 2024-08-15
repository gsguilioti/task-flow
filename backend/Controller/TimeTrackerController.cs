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
    public class TimeTrackerController : ControllerBase
    {
        private readonly ITimeTrackerRepository _repository;
        private readonly ITimeTrackerService _timeTrackerService;
        public TimeTrackerController(ITimeTrackerRepository repository, ITimeTrackerService timeTrackerService)
        {
            _repository = repository;
            _timeTrackerService = timeTrackerService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var timeTracker = _repository.GetById(id);

            if (timeTracker == null)
                return NotFound(new { Message = "Not Found" });

            var timeTrackerDto = new TimeTrackerDto(timeTracker);
            return Ok(timeTrackerDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var timeTrackers = _repository.GetAll();
            if (timeTrackers.ToList().Count == 0)
                return Ok(new { Message = "Nenhum registro encontrado" });

            return Ok(timeTrackers);
        }

        [HttpGet("/timetracker/task/{id}")]
        public IActionResult GetAllByTask(int id)
        {
            var timeTrackers = _repository.GetAllByTask(id);
            if (timeTrackers.ToList().Count == 0)
                return Ok(new { Message = "Nenhum registro encontrado" });

            return Ok(timeTrackers);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(TimeTrackerDto dto)
        {
            var timeTracker = _timeTrackerService.CreateTimeTracker(dto);
            _repository.Create(timeTracker);
            return Created("/timeTrackers", timeTracker);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TimeTrackerDto dto)
        {
            var timeTracker = _repository.GetById(id);

            if (timeTracker == null)
                return NotFound(new { Message = "Not Found" });

            timeTracker.MapDto(dto);
            _repository.Update(timeTracker);
            return Ok(timeTracker);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var timeTracker = _repository.GetById(id);

            if (timeTracker == null)
                return NotFound(new { Message = "Not Found" });

            _repository.Delete(timeTracker);
            return NoContent();
        }
    }
}
