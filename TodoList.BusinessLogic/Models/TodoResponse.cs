using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TodoList.DataAccess.Models;

namespace TodoList.BusinessLogic.Models
{
    public class TodoResponse
    {
        public List<Todo> Todos { get; set; } = new List<Todo>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
