using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.BusinessLogic.Models;
using TodoList.DataAccess.Models;

namespace TodoList.BusinessLogic.Interfaces
{
    public interface ITodo
    {
        IEnumerable<Todo> GetTodos();
        Task<Todo> GetTodoAsync(Guid id);
        Task<Todo> AddTodoAsync(TodoRequest todo);
        Task<Todo> UpdateTodoAsync(Guid id, TodoRequest todo);
        Task<bool> RemoveTodoAsync(Guid id);
    }
}
