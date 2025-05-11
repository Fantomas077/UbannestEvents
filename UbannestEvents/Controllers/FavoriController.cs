using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UbannestEvents.Data;
using UbannestEvents.Models;

namespace UbannestEvents.Controllers
{
    public class FavoriController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public FavoriController(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {  
            _context = context; 
            _userManager = userManager;
            _signInManager = signInManager;
            
            
        }
        public async Task< IActionResult> Index()
        {
            var user= await _userManager.GetUserAsync(User);
            var obj= await _context.Favoris.Include(r=>r.Event).Where(r=>r.UserId==user.Id).ToListAsync();

            return View(obj);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ToggleFavori(int EventID)
        {
            var user = await _userManager.GetUserAsync(User);

            var favori = _context.Favoris.FirstOrDefault(f => f.UserId == user.Id && f.EventID == EventID);

            if (favori == null)
            {
                var obj = new Favori()
                {
                    UserId = user.Id,
                    EventID = EventID,
                    DateAdd = DateTime.Now
                };
                _context.Favoris.Add(obj);
            }
            else
            {
                _context.Favoris.Remove(favori);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("EventsDetails", "Event", new { id = EventID });
        }



    }
}
