using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.DTOs
{
    public class UserRegisterDto 
    {
        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}