using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UbannestEvents.Data;
using UbannestEvents.Models;
using UbannestEvents.ViewModels;

namespace UbannestEvents.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var now = DateTime.Now;
            var today = now.Date;
            var tomorrow = today.AddDays(1);

            var Incoming = _context.Events
                .Include(r => r.Category)
                .Where(r => r.StartDate >= tomorrow) 
                .Take(4)
                .ToList();

            var Today = _context.Events
                .Include(r => r.Category)
                .Where(r => r.StartDate >= today && r.StartDate < tomorrow)
                .Take(4)
                .ToList();
            var Most = _context.Events
                    .Include(r => r.Category)
                    .OrderByDescending(r => r.ViewCount) 
                    .Take(4)
                    .ToList();

            var obj = new HomeVM()
            {
                IncommingsEvent = Incoming,
                TodayEvents = Today,
                MostView = Most,
                Categories = _context.Categories.ToList()
            };

            return View(obj);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
