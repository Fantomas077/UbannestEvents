using Microsoft.AspNetCore.Identity;
using UbannestEvents.Models;

namespace UbannestEvents.Areas.Admin.Models
{
    public class HomeVM
    {
        public List<Event>?Events { get; set; }
        public List<Category>? Categories { get; set; }
        public List<ApplicationUser>? users { get; set; }
       


    }
}
