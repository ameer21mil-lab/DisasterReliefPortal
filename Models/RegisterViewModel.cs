using System.ComponentModel.DataAnnotations;

namespace YourNamespace.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // Add FullName property
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        // Add Role property
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; } // New Role property
    }
}
