using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UbannestEvents.Data;
using UbannestEvents.Models;

namespace UbannestEvents.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public EventController(AppDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var obj= _context.Events.Include(r=>r.Category).ToList();
            
            return View(obj);
        }
        public IActionResult Kat(string name)
        {
            var events = _context.Events.Include(e => e.Category).Where(r=>r.Category.Name==name).ToList();

          

           
            return View("Index", events);
        }

        public async Task<IActionResult> KommendeEvents()
        {
            var kommendeEvents = await _context.Events
                .Include(r => r.Category)
                .Where(r => r.StartDate > DateTime.Now)
                .ToListAsync();

            

            return View("Index", kommendeEvents); 
        }

        public async Task<IActionResult> MostWached()
        {
            var Most =await _context.Events
                   .Include(r => r.Category)
                   .OrderByDescending(r => r.ViewCount) 
                   .Take(4)
                   .ToListAsync();
            return View("Index",Most);
        }

        public async Task<IActionResult> HeutigeEvents()
        {
            var now = DateTime.Now;
            var today = now.Date;
            var tomorrow = today.AddDays(1);
            var HeutigeEvents = await _context.Events
                .Include(r => r.Category)
                .Where(r => r.StartDate == today && r.StartDate < tomorrow)
                .ToListAsync();



            return View("Index", HeutigeEvents);
        }
        [HttpGet]
        public IActionResult EventsDetails(int id)
        {
            var obj = _context.Events.Include(r => r.Category).Include(r=>r.Komments).ThenInclude(r=>r.User).FirstOrDefault(r=>r.Id==id);
            if (obj == null)
            {
                return NotFound(obj);
            }
            obj.ViewCount++;
           _context.SaveChanges();
            var userId = _userManager.GetUserId(User);

            // Vérifie si cet utilisateur a déjà ajouté ce favori
            ViewBag.EstFavori = false;

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.EstFavori = _context.Favoris.Any(f => f.UserId == userId && f.EventID == id);
            }


            return View(obj);
        }

       


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(string CommentText, int EventID)
        {
            var user= await _userManager.GetUserAsync(User);
            var obj = new Comment()
            {
                CommenText = CommentText,
                UserId = user.Id,
                EventID =EventID

            };
            _context.Komments.Add(obj);
            _context.SaveChanges();

            return RedirectToAction("EventsDetails", new { id = EventID });


        }
    }
}
