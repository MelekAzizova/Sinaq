using Edukatr.Contexts;
using Edukatr.Models;
using Edukatr.ViewModels.PositionVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edukatr.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class PositionController : Controller
    {
        private readonly EdukateDbContext _db;

        public PositionController(EdukateDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Positions.Select(s => new PositionListItemVM
            {
                Id=s.Id,
                Name=s.Name

            }).ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PositionCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            Position position = new Position
            {
                Name=vm.Name
            };
            await _db.Positions.AddAsync(position);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Positions.FindAsync(id);
            if (data == null) return NotFound();
            return View(new PositionUpdateVM
            {
                Name=data.Name
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,PositionUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Positions.FindAsync(id);
            if (data == null) return NotFound();
            data.Name = vm.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Positions.FindAsync(id);
            if (data == null) return NotFound();
            _db.Positions.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
