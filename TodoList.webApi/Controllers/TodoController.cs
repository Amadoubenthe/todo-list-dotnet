﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.BusinessLogic.Interfaces;
using TodoList.BusinessLogic.Models;

namespace TodoList.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        /*private readonly ITodo _PersonScore;

        public PersonScoreController(IPersonScore personScore)
        {
            _PersonScore = personScore;
        }*/

        private readonly ITodo _TodoService;

        public TodoController(ITodo todoService)
        {
            _TodoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_TodoService.GetTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var todo = await _TodoService.GetTodoAsync(id);

            if (todo == null)
            {
                return NotFound("Todo not found");
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoRequest todo)
        {
            var todoCreated = await _TodoService.AddTodoAsync(todo);

            return Ok(todoCreated);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TodoRequest todoRequest)
        {
            var todo = await _TodoService.UpdateTodoAsync(id, todoRequest);

            return Ok(todo);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _TodoService.RemoveTodoAsync(id);

            if (response != true) return NotFound("Todo not found");


            return Ok("Todo deleted");
        }

    }
}
