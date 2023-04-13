using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.BusinessLogic.Interfaces;
using TodoList.BusinessLogic.Models;
using TodoList.DataAccess.Data;
using TodoList.DataAccess.Models;

namespace TodoList.BusinessLogic.Services
{
    public class TodoService : ITodo
    {
        public readonly TodoApiDbContext _DbContext;

        public TodoService(TodoApiDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Todo> AddTodoAsync(TodoRequest todo)
        {
            Todo todoAdd = new Todo()
            {
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status,
                CreatedAt = DateTime.Now,
            };

            await _DbContext.Todos.AddAsync(todoAdd);
            await _DbContext.SaveChangesAsync();

            return todoAdd;
        }

        public async Task<Todo> GetTodoAsync(Guid id)
        {
            var todo = await _DbContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return null;
            }

            return todo;
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _DbContext.Todos.ToList();
        }

        public IEnumerable<Todo> GetTodos(int pageNumber = 1, int pageSize = 10)
        {
            var tasks = _DbContext.Todos.ToList();

            var pagedTasks = tasks.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return pagedTasks;
        }

        /* public async Task<ActionResult<IEnumerable<Taches>>> GetTasks(int pageNumber = 1, int pageSize = 10)
         {
             var tasks = await _itachesService.GetAllTasks();
             var pagedTasks = tasks.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
             return Ok(pagedTasks);
         }*/

        public async Task<TodoResponse> GetTodosAsync(int page)
        {
            if (_DbContext.Todos == null)
                return null;

            var pageResults = 3f;
            var pageCount = Math.Ceiling(_DbContext.Todos.Count() / pageResults);

            var todos = await _DbContext.Todos
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new TodoResponse
            {
                Todos = todos,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return response;
        }

        public async Task<bool> RemoveTodoAsync(Guid id)
        {
            var todo = await _DbContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return false;
            }

            _DbContext.Remove(todo);

            await _DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Todo> UpdateTodoAsync(Guid id, TodoRequest todoRequest)
        {
            var todo = await _DbContext.Todos.FindAsync(id);

            if(todo == null)
            {
                return null;
            }

            todo.Status = todoRequest.Status;
            todo.Title = todoRequest.Title;
            todo.Description = todoRequest.Description;
            todo.UpdatedAt = DateTime.Now;

            await _DbContext.SaveChangesAsync();

            return todo;
        }
    }
}
