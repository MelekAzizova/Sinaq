using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PORTFOLIO.Contexts;

namespace PORTFOLIO.Controllers
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
            var data = await _db.Detals.ToListAsync();
           return View(data);
        }
    }
}
