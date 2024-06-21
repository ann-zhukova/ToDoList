using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoListDb _context;
        public HomeController(ILogger<HomeController> logger, ToDoListDb context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult TaskList()
        {
            var ToDoList = _context.ToDoTasks.ToList();
            return View(ToDoList);
        }
        public IActionResult CreateEditTask(int? id)
        {
            if(id != null) 
            {
                var ex = _context.ToDoTasks.SingleOrDefault(t => t.Id == id);
                return View(ex);
            }
            return View();
        }
        public IActionResult DeleteTask(int id)
        {
            var ex = _context.ToDoTasks.SingleOrDefault(t => t.Id == id);
            if (ex != null)
            {
                _context.ToDoTasks.Remove(ex);
                _context.SaveChanges();
            }
            return RedirectToAction("TaskList");
        }

        public IActionResult CreateEditForm(ToDoTask toDoTask)
        {
            var existingTask = _context.ToDoTasks.Find(toDoTask.Id);

            if (existingTask == null)
            {
                _context.ToDoTasks.Add(toDoTask);
            }
            else
            {
                _context.Entry(existingTask).CurrentValues.SetValues(toDoTask);
            }
            _context.SaveChanges();
            return RedirectToAction("TaskList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
