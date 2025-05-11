using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UbannestEvents.Areas.Admin.Models;
using UbannestEvents.Data;
using UbannestEvents.Models;

namespace UbannestEvents.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var obj= _context.Events.ToList();
            var obj2= _context.Categories.ToList();
            var obj3 = _userManager.Users.ToList();




            var co = new HomeVM()
            {
                Events = obj,
                Categories=obj2,

                users= obj3

            };
            return View(co);
        }
    }
}
