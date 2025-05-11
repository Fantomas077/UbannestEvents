using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UbannestEvents.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; } 


        [Required]
        public string CommenText { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public int EventID { get; set; }
        [ForeignKey("EventID")]
        [ValidateNever]
        public Event Event { get; set; }

    }
}
