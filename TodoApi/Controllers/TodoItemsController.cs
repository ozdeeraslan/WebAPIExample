using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _todoContet;

        public TodoItemsController(TodoContext todoContext)
        {
            _todoContet = todoContext;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetItems()
        {
            return _todoContet.TodoItems.OrderBy(x=>x.Done).ToList();
        }
    }
}
