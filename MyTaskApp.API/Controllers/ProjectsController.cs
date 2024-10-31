using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTaskApp.Application.InputModels;
using MyTaskApp.Application.Interfaces;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.API.Controllers
{
    [Route("api/projects")]
    [Authorize]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IProjectRepository _repository;

        public ProjectsController(IProjectService projectService, IProjectRepository repository)
        {
            _projectService = projectService;
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

        [HttpGet("user/{idUser}")]
        public async Task<IActionResult> GetByUSerId(int idUser)
        {
            var result = await _repository.GetByUserIdAsync(idUser);

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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProjectInputModel inputModel)
        {
            try
            {
                await _projectService.UpdateAsync(inputModel);

                return CreatedAtAction(nameof(GetById), new { id = inputModel.Id }, inputModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _projectService.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
