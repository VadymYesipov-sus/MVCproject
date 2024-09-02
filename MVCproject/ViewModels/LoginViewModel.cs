using System.ComponentModel.DataAnnotations;

namespace MVCproject.ViewModels
{
    public class LoginViewModel
    {
        //validation in domain model is a design smell so we do it here
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email and address is required")]
        public string EmailAddress { get; set; }
        //validation annotations
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
