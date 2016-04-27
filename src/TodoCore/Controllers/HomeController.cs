using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoCore.Model;
using Microsoft.AspNetCore.Authorization;

namespace TodoCore.Controllers
{
    //[Authorize()]
    public class HomeController : Controller
    {
        private TodoContext _db;

        public HomeController(TodoContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Todos.ToList());
        }

        [HttpPost("checkTodo")]
        public async Task<IActionResult> CheckTodo(int id)
        {
            var todoToRemove = _db.Todos.FirstOrDefault(x => x.id == id);
            if(todoToRemove != null)
            {
                _db.Todos.Remove(todoToRemove);
                await _db.SaveChangesAsync();
            }
            return new RedirectResult("~/");
        }

        [HttpPost("addTodo")]
        public async Task<IActionResult> AddTodo(Todo todoToAdd)
        {
            _db.Todos.Add(todoToAdd);
            await _db.SaveChangesAsync();
            return new RedirectResult("~/");
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
