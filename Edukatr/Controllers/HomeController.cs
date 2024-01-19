using Edukatr.Contexts;
using Edukatr.ViewModels.InstructorVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edukatr.Controllers
{
    public class HomeController : Controller
    {
        private readonly EdukateDbContext _db;

        public HomeController(EdukateDbContext db)
        {
            _db = db;
        }

        public async  Task<IActionResult> Index()
        {
            var data = await _db.Instructors.Select(s => new InstructorListItemVM
            {
                Id = s.Id,
                Image = s.Image,
                Positions = s.Positions,
                Name = s.Name
            }).ToListAsync();
            return View(data);
        }
    }
}
