using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private  List<TodoItem> items = new();

        // GET: api/todo
        [HttpGet]
        public IEnumerable<TodoItem> Get() => items;

        // POST: api/todo
        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            item.Id = items.Count + 1;
            items.Add(item);
            return Ok(item);
        }

        // PUT: api/todo/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem updated)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();

            item.Title = updated.Title;
            item.IsComplete = updated.IsComplete;
            return Ok(item);
        }

        // DELETE: api/todo/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();

            items.Remove(item);
            return NoContent();
        }
    }
}
