using System.ComponentModel.DataAnnotations;

namespace MVCproject.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email and address is required")]
        public string EmailAddress { get; set; } = null!;
        //validation annotations
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "You need to confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "passwords do not match")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
