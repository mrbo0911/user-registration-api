using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Application.DTOs
{
    public class UserUpdateDto 
    {
        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}