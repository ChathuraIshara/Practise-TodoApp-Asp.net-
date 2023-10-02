using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContextDb _db;
        public TodoController(TodoContextDb db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            List<Todo> todos = _db.Todos.ToList();
            return View(todos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Todo obj)
        {
            if (ModelState.IsValid)
            {
                _db.Todos.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Todo");

            }
            return View();


        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Todo? todo = _db.Todos.Find(Id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(Todo obj)
        {
            if(ModelState.IsValid)
            {
                _db.Todos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();


        }

        public IActionResult delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Todo? todo = _db.Todos.Find(Id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);

        }
        [HttpPost,ActionName("delete")]
        public IActionResult deletepost(int? Id)
        {
            Todo todo = _db.Todos.Find(Id);
            if (todo==null)
            {
                return NotFound();
                
            }
            _db.Todos.Remove(todo);
            _db.SaveChanges();
            return RedirectToAction("Index","Todo");


        }
    }
}
