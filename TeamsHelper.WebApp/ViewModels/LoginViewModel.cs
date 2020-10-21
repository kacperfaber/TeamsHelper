using System.ComponentModel.DataAnnotations;

namespace TeamsHelper.WebApp
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(5), MaxLength(15)]
        public string Password { get; set; }
    }
}