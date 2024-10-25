using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTaskApp.API.Models;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTaskInputModel inputModel)
        {
            var task = new ProjectTask(inputModel.Title, inputModel.Description, inputModel.IdUser, inputModel.IdProject);

            var idTask = await _repository.AddAsync(task);

            if (idTask == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id = idTask }, inputModel);
        }
    }
}
