using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreSqlDb.Models;

namespace DotNetCoreSqlDb.Controllers
{
    public class TodosController : Controller
    {
        private readonly MyDatabaseContext _context;

        public TodosController(MyDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => {
                return View(new List<Todo>());
            });
        }

        // GET: Todos
        [Route("{token}")]
        [HttpGet]
        public async Task<IActionResult> Index(string token, string sortOrder)
        {
            ViewData["AlphabeticalSort"] = sortOrder == "Description" ? "Description_Desc" : "Description";
            ViewData["DateAddedSort"] = String.IsNullOrEmpty(sortOrder) ? "Date_Added_Desc" : "";
            ViewData["DueDateSort"] = sortOrder == "Due_Date" ? "Due_Date_Desc" : "Due_Date";

            var allTodos = await _context.Todo.ToListAsync();
            var clientTodos = allTodos.Where(todo => todo.Token == token);

            switch (sortOrder)
            {
                case "Description_Desc":
                    clientTodos = clientTodos.OrderByDescending(s => s.Description).ToList();
                    break;
                case "Description":
                    clientTodos = clientTodos.OrderBy(s => s.Description).ToList();
                    break;
                case "Due_Date_Desc":
                    clientTodos = clientTodos.OrderByDescending(s => s.DueDate).ToList();
                    break;
                case "Due_Date":
                    clientTodos = clientTodos.OrderBy(s => s.DueDate).ToList();
                    break;
                case "Date_Added_Desc":
                    clientTodos = clientTodos.OrderByDescending(s => s.DateAdded).ToList();
                    break;
                default:
                    clientTodos = clientTodos.OrderBy(s => s.DateAdded).ToList();
                    break;
            }

            return View(clientTodos);
        }

        // GET: Todos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // GET: Todos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Token,Description,DueDate")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Token,Description,DueDate")] Todo todo)
        {
            if (id != todo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoExists(todo.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todo = await _context.Todo.FindAsync(id);
            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.ID == id);
        }
    }
}
