using System.ComponentModel.DataAnnotations;

namespace TeamsHelper.WebApp
{
    public class RegisterViewModel : ViewModel
    {
        [Required]
        [MinLength(3), MaxLength(18)]
        public string DisplayName { get; set; }
        
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
        
        [Required]
        [MinLength(5), MaxLength(15)]
        public string Password { get; set; }
    }
}