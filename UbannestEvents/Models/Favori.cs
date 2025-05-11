using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UbannestEvents.Models
{
    public class Favori
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateAdd { get; set; } = DateTime.Now;

        // Clé étrangère vers l'utilisateur
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; }

        // Clé étrangère vers l'événement
        public int EventID { get; set; }

        [ForeignKey("EventID")]
        [ValidateNever]
        public Event Event { get; set; }
    }
}
