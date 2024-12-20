﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTaskApp.Application.InputModels;
using MyTaskApp.Application.Interfaces;
using MyTaskApp.Application.Services;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.API.Controllers
{
    [Route("api/tasks")]
    [Authorize]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _repository;

        public TasksController(ITaskService taskService, ITaskRepository repository)
        {
            _taskService = taskService;
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
        public async Task<IActionResult> Post([FromBody] CreateTaskInputModel inputModel)
        {
            var task = new ProjectTask(inputModel.Title, inputModel.Description, inputModel.IdUser, inputModel.IdProject);

            var idTask = await _repository.AddAsync(task);

            if (idTask == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id = idTask }, inputModel);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTaskInputModel inputModel)
        {
            try
            {
                await _taskService.UpdateAsync(inputModel);

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
                await _taskService.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("start/{idTask}")]
        public async Task<IActionResult> Start(int idTask)
        {
            try
            {
                await _taskService.StartAsync(idTask);

                return NoContent();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("finish/{idTask}")]
        public async Task<IActionResult> Finish(int idTask)
        {
            try
            {
                await _taskService.FinishAsync(idTask);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
