using System.ComponentModel.DataAnnotations;

namespace UbannestEvents.ViewModels
{
    public class ResetPasswordVM
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Le mot de passe de confirmation ne correspond pas.")]
        public string ConfirmPassword { get; set; }

       
    }

}
