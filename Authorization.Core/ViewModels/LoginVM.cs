using System.ComponentModel.DataAnnotations;

namespace Authorization.Core.ViewModels
{
    public class LoginVM
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be from {2} to {1} characters long", MinimumLength = 5)]
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "Username must contain only letters and numbers")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be from {2} to {1} characters long", MinimumLength = 6)]
        [RegularExpression(@".*[0-9].*", ErrorMessage = "Password must contain at least 1 number")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
