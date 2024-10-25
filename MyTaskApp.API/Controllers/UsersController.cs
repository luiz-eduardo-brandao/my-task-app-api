using Microsoft.AspNetCore.Mvc;
using MyTaskApp.API.Models;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
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
        public async Task<IActionResult> Post([FromBody] CreateUserInputModel inputModel)
        {
            var user = new User(
                inputModel.FullName,
                inputModel.BirthDate,
                inputModel.PhoneNumber,
                inputModel.Bio,
                inputModel.ProfileImage,
                inputModel.Email,
                inputModel.Password,
                inputModel.Role
                );

            var result = await _repository.AddAsync(user);

            if (result == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id = result }, inputModel);
        }
    }
}
