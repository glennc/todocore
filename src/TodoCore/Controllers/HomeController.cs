using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoCore.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace TodoCore.Controllers
{
    [Authorize()]
    public class HomeController : Controller
    {
        private TodoContext _db;

        public HomeController(TodoContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            //todo: probably need a service to deal with some of this.
            var currentUserId = int.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var user = await _db.Users.Include(x => x.Todos).FirstOrDefaultAsync(x=>x.Id == currentUserId);
            if (user != null)
            {
                return View(user.Todos.ToList());
            }

            return View(Enumerable.Empty<Todo>());
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

            var currentUserId = int.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == currentUserId);
            if (user == null)
            {
                user = new User
                {
                    Id = currentUserId,
                    Name = HttpContext.User.Identity.Name
                };
                _db.Users.Add(user);
            }

            user.Todos.Add(todoToAdd);

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
