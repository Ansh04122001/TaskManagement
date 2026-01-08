using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Models;
namespace TaskManagement.Controllers
{


    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();   

            return RedirectToAction("Tasks", "Index");
        }
        // READ + SEARCH
        public IActionResult Index(string search)
        {
            var tasks = _context.Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                tasks = tasks.Where(t => t.TaskTitle.Contains(search));

            return View(tasks.ToList());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var task = await _context.Tasks
                                     .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                return NotFound();

            return View(task);
        }
        // CREATE
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }


        // UPDATE
        public IActionResult Edit(int id)
        {
            return View(_context.Tasks.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskItem task)
        {
            if (id != task.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingTask = await _context.Tasks.FindAsync(id);
                if (existingTask == null) return NotFound();

                // Update only editable fields
                existingTask.TaskTitle = task.TaskTitle;
                existingTask.TaskDescription = task.TaskDescription;
                existingTask.TaskDueDate = task.TaskDueDate;
                existingTask.TaskStatus = task.TaskStatus;
                existingTask.TaskRemarks = task.TaskRemarks;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }


        // DELETE
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
