using System.ComponentModel.DataAnnotations;

namespace Entities

{
    public class LogInUser
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
