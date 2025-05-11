using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UbannestEvents.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConnfirmPassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? ReturnUrl { get; set; }
        [Required(ErrorMessage = "Please select a role")]
        public string SelectedRole { get; set; }  // <- à ajouter
        [ValidateNever]
        public List<SelectListItem> ? RoleLIst { get; set; }  
    }
}
