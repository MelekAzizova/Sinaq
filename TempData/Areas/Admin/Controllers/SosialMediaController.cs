using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempData.Contexts;
using TempData.Helpers;
using TempData.Models;
using TempData.ViewModels.SosialMediaVM;
using TempData.ViewModels.TeamVM;

namespace TempData.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SosialMediaController : Controller
    {
        public SosialMediaController(TempDbContext db)
        {
            _db = db;
        }

        TempDbContext _db { get; }
        public async Task<IActionResult> Index()
        {
            var data = await _db.SosialMedias.Select(s => new SMListItemVM
            {
                Id=s.Id,
                Icon=s.Icon,
                Name=s.Name

            }).ToListAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SMCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            SosialMedia sm = new SosialMedia
            {
                Icon=await vm.Icon.SaveAsync(PathConst.Image),
                Name=vm.Name



            };
            await _db.SosialMedias.AddAsync(sm);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.SosialMedias.FindAsync(id);
            if (data == null) return NotFound();
            _db.SosialMedias.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.SosialMedias.FindAsync(id);
            if (data == null) return NotFound();
            return View(new SMUpdateVM
            {
                Name=data.Name

            });

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int? id, SMUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.SosialMedias.FindAsync(id);
            if (data == null) return NotFound();
            data.Name = vm.Name;
            data.Icon = await vm.Icon.SaveAsync(PathConst.Image);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
