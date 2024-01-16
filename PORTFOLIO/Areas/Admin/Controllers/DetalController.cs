using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PORTFOLIO.Contexts;
using PORTFOLIO.Helpers;
using PORTFOLIO.Models;
using PORTFOLIO.ViewModels.DetalVM;

namespace PORTFOLIO.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DetalController : Controller
    {
        public DetalController(TempDbContext db)
        {
            _db = db;
        }

        TempDbContext _db { get;  }
        public async Task<IActionResult> Index()
        {
            var data = await _db.Detals.Select(s => new DetalListItemVM
            {
                Id = s.Id,
                Image = s.Image,
                Description = s.Description,
                Name = s.Name
            }).ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DetalCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            Detal detal = new Detal
            {
               // Image=vm.Image,
                Image =await vm.Image.SaveAsync(PathConst.Detal),
                Description = vm.Description,
                Name = vm.Name
            };
            await _db.Detals.AddAsync(detal);
            await  _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Detals.FindAsync(id);
            if (data == null) NotFound();
             _db.Detals.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
;
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Detals.FindAsync(id);
            if (data == null) return NotFound();
            return View(new DetalUpdateVM
            {
                Name = data.Name,
                Description = data.Description,
               
            });
            

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,DetalUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Detals.FindAsync(id);
            if (data == null) return NotFound();
            data.Name = vm.Name;
            data.Description = vm.Description;
            data.Image = await vm.Image.SaveAsync(PathConst.Detal);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
