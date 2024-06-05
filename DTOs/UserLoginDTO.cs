using System.ComponentModel.DataAnnotations;

namespace Project
{
    public class UserLoginDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(30, ErrorMessage = "name must be less than 30 characters long")]
        public string Password { get; set; }
    }
}
