using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KMP.Models;
using DateTimeExtensions;

namespace KMP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly kmpContext _context;

        public TodoController(kmpContext context)
        {
            _context = context;
        }

        public IQueryable<Todo> GetAllTodo()
        {
            return _context.Todo.AsQueryable();
        }

        private DateTime getToday(DateTime u, int add) {
            return new DateTime(u.Year, u.Month, u.Day).AddDays(add);
        }

        // GET: api/Todo
        // Accepted filter: Start=now/toworrow/current_week
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodo(
            [FromQuery(Name = "Start")] string start_date
        )
        {
            if (start_date == null) {
                return await _context.Todo.ToListAsync();
            }

            DateTime now = DateTime.Now;
            DateTime today = new DateTime(now.Year, now.Month, now.Day);
            if (start_date == "now")
            {
                return await GetAllTodo().Where(t => t.Started == today).ToListAsync();
            }
            else if (start_date == "tomorrow")
            {
                today = today.AddDays(1);
                return await GetAllTodo().Where(t => t.Started == today).ToListAsync();
            }
            else if (start_date == "current_week")
            {
                var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                var next_monday = monday.AddDays(7);
                return await GetAllTodo()
                    .Where(t => t.Started >= monday)
                    .Where(t => t.Started < next_monday)
                    .ToListAsync();
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await _context.Todo.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            _context.Todo.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> DeleteTodo(int id)
        {
            var todo = await _context.Todo.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.Id == id);
        }
    }
}
