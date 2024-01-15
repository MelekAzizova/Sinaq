using Blog.Context;
using Blog.Helpers;
using Blog.Models;
using Blog.ViewModels.NewVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class nEWSController : Controller
    {
        public nEWSController(TempDbContext db)
        {
            _db = db;
        }

        TempDbContext _db { get; }
        public async Task<IActionResult> Index()
        {
            var data = await _db.News.Select(s => new NewsListItemVM
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Image = s.Image
            }).ToListAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewsCreateVM vm)
        {

         
            if (!ModelState.IsValid) return View(vm);
            News news = new News
            {
                Title = vm.Title,
                Description = vm.Description,
               
                Image =await vm.Image.SaveAsync(PathConst.News)
            };
            await _db.News.AddAsync(news);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.News.FindAsync(id);
            if (data == null) return NotFound();
            return View(new NewsUpdateVM
            {
                Title=data.Title,
                Description=data.Description,
                


        });

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,NewsUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.News.FindAsync(id);
            if (data == null) return NotFound();
            data.Title = vm.Title;
            data.Description = vm.Description;
            data.Image = await vm.Image.SaveAsync(PathConst.News);
           
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.News.FindAsync(id);
            if (data == null) return NotFound();
                 _db.News.Remove(data);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
