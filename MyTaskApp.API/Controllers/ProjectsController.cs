using Microsoft.AspNetCore.Mvc;
using MyTaskApp.API.Models;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _repository;

        public ProjectsController(IProjectRepository repository)
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
        public async Task<IActionResult> Post([FromBody] CreateProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title , inputModel.Description, inputModel.ImageUrl, inputModel.Level, inputModel.IdUser);

            var idProject = await _repository.AddAsync(project);

            if (idProject == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id = idProject }, inputModel);
        }
    }
}
