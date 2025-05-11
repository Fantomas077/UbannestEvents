using Microsoft.AspNetCore.Identity;

namespace UbannestEvents.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<Favori>? Favoris { get; set; }
    }
}
