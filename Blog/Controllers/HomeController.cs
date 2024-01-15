
using Blog.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(TempDbContext db)
        {
            _db = db;
        }

        TempDbContext _db { get; }
       
        public async Task<IActionResult> Index()
        {
            var data = await _db.News.ToListAsync();
            return View(data);
        }

       
    }
}
