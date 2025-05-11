using System.ComponentModel.DataAnnotations;

namespace UbannestEvents.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Event>? Events { get; set; }
    }
}
