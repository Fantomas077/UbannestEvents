using System.ComponentModel.DataAnnotations;

namespace UbannestEvents.ViewModels
{
    public class LoginVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberME { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
