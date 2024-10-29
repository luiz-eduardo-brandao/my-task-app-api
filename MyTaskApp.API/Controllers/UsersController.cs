using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTaskApp.Application.InputModels;
using MyTaskApp.Application.Interfaces;
using MyTaskApp.Application.Services;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _repository;

        public UsersController(IUserService userService, IUserRepository repository)
        {
            _userService = userService;
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
        [AllowAnonymous]
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

            //return CreatedAtAction(nameof(GetById), new { id = result }, inputModel);
            return Ok();
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserInputModel inputModel)
        {
            try
            {
                var user = await _userService.LoginUser(inputModel);

                if (user == null)
                    return BadRequest("Usuário ou senha inválidos!");

                return Ok(user);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
