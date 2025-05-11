using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UbannestEvents.Data;
using UbannestEvents.Models;

namespace UbannestEvents.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            
            if(_context.Categories.Any(o=>o.Name==category.Name))
            {
                ModelState.AddModelError($"Name", $" Die Kategorie {category.Name} existiert schon");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category ?obj= _context.Categories.FirstOrDefault(c => c.Id == id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {

            if (_context.Categories.Any(o => o.Name == category.Name))
            {
                ModelState.AddModelError($"Name", $" Die Kategorie {category.Name} existiert schon");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category? obj = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
