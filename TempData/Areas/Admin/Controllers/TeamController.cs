using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempData.Contexts;
using TempData.Helpers;
using TempData.Models;
using TempData.ViewModels.TeamVM;

namespace TempData.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        public TeamController(TempDbContext db)
        {
            _db = db;
        }

        TempDbContext _db { get; }
        public async Task<IActionResult> Index()
        {
            var data = await _db.Teams.Select(s => new TeamListItemVM
            {
                Id=s.Id,
                Position=s.Position,
                Image=s.Image

            }).ToListAsync();
            return View(data);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(TeamCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            Team team = new Team
            {
                Position=vm.Position,
                Image=await vm.Image.SaveAsync(PathConst.Image)
            };
            await _db.Teams.AddAsync(team);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Teams.FindAsync(id);
            if (data == null) return NotFound();
            _db.Teams.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Teams.FindAsync(id);
            if (data == null) return NotFound();
            return View(new TeamUpdateVM
            {
                Position=data.Position

            });

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int? id,TeamUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Teams.FindAsync(id);
            if (data == null) return NotFound();
            data.Position = vm.Position;
            data.Image = await vm.Image.SaveAsync(PathConst.Image);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
