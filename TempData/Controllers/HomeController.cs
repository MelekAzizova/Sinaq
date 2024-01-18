using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempData.Contexts;

namespace TempData.Controllers
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
            var data = await _db.Teams.ToListAsync();
            return View(data);
        }
    }
}
