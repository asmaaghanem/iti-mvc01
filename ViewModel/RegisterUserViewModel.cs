using System.ComponentModel.DataAnnotations;

namespace LMS.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}