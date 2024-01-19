using Edukatr.Contexts;
using Edukatr.Helpers;
using Edukatr.Models;
using Edukatr.ViewModels.InstructorVM;
using Edukatr.ViewModels.PositionVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Edukatr.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class InstructorController : Controller
    {
        private readonly EdukateDbContext _db;

        public InstructorController(EdukateDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Instructors.Select(s => new InstructorListItemVM
            {
                Id=s.Id,
                Image=s.Image,
                Positions=s.Positions,
                Name=s.Name
            }).ToListAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.Positions = new SelectList(_db.Positions, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InstructorCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            ViewBag.Positions = new SelectList(_db.Positions, "Id", "Name");
            Instructor ınstructor = new Instructor
            {
                Image=await vm.Image.SaveAsync(PathConst.Images),
                Name = vm.Name,
                PositionId=vm.PositionId
                
            };
            await _db.Instructors.AddAsync(ınstructor);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Instructors.FindAsync(id);
            if (data == null) return NotFound();
            ViewBag.Positions = new SelectList(_db.Positions, "Id", "Name");
            return View(new InstructorUpdateVM
            {
                PositionId=data.PositionId,
                Name = data.Name
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, InstructorUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Instructors.FindAsync(id);
            if (data == null) return NotFound();
            ViewBag.Positions = new SelectList(_db.Positions, "Id", "Name");
            data.Name = vm.Name;
            data.PositionId = vm.PositionId;
            data.Image = await vm.Image.SaveAsync(PathConst.Images);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Instructors.FindAsync(id);
            if (data == null) return NotFound();
            _db.Instructors.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
