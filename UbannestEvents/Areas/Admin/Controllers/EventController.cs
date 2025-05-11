using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UbannestEvents.Data;
using UbannestEvents.Models;

namespace UbannestEvents.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        public readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var obj = _context.Events.Include(r => r.Category).ToList();
            return View(obj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event obj, IFormFile ImageFile)
        {
            if(obj.StartDate<DateTime.Now)
            {
                ModelState.AddModelError("StartDate", "StartDate Kann nicht kleiner als das Datum vom heute");
            }
            if (obj.StartDate > obj.EndDate)
            {
                ModelState.AddModelError("StartDate", "StartDate Kann nicht größer als das Enddate ");
            }
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string org = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Cover");
                    if (!Directory.Exists(org))
                    {
                        Directory.CreateDirectory(org);
                    }

                    obj.ImgageCovername = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    string imagePath = Path.Combine(org, obj.ImgageCovername);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                }


                _context.Events.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var obj= _context.Events.FirstOrDefault(e => e.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
         
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event obj, IFormFile ImageFile)
        {
            if (obj.StartDate < DateTime.Now)
            {
                ModelState.AddModelError("StartDate", "StartDate Kann nicht kleiner als das Datum vom heute");
            }
            if (obj.StartDate > obj.EndDate)
            {
                ModelState.AddModelError("StartDate", "StartDate Kann nicht größer als das Enddate ");
            }
            var obj1 = _context.Events.AsNoTracking().FirstOrDefault(x => x.Id == obj.Id);
            if (ModelState.IsValid)
            {
                if(obj1!=null)
                {

                    string org = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\images\\Cover\\" + obj1.ImgageCovername);
                    if (System.IO.File.Exists(org))
                    {
                        System.IO.File.Delete(org);
                    }
                }

                if (ImageFile != null)
                {
                    string org = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Cover");
                    if (!Directory.Exists(org))
                    {
                        Directory.CreateDirectory(org);
                    }

                    obj.ImgageCovername = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    string imagePath = Path.Combine(org, obj.ImgageCovername);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                }
                // Detach l'entité existante si elle est suivie (tracking)
                _context.Entry(obj1).State = EntityState.Detached;

                _context.Events.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View(obj);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = _context.Events.FirstOrDefault(e => e.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Event obj)
        {
            var obj1 = _context.Events.AsNoTracking().FirstOrDefault(x => x.Id == obj.Id);
            if (ModelState.IsValid)
            {
                if (obj1 != null)
                {

                    string org = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\images\\Cover\\" + obj1.ImgageCovername);
                    if (System.IO.File.Exists(org))
                    {
                        System.IO.File.Delete(org);
                    }
                }

              
                // Detach l'entité existante si elle est suivie (tracking)
                _context.Entry(obj1).State = EntityState.Detached;

                _context.Events.Remove(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }
    }
}
