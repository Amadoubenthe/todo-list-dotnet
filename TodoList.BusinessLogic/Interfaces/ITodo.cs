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
        IEnumerable<Todo> GetTodos(int pageNumber = 1, int pageSize = 10);
        Task<Todo> GetTodoAsync(Guid id);
        Task<Todo> AddTodoAsync(TodoRequest todo);
        Task<Todo> UpdateTodoAsync(Guid id, TodoRequestUpdate todo);
        Task<bool> RemoveTodoAsync(Guid id);
    }
}
