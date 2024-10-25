using Microsoft.AspNetCore.Mvc;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.API.Controllers
{
    [Route("api/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuRepository _repository;

        public MenusController(IMenuRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();

            return Ok(result);
        }
    }
}
