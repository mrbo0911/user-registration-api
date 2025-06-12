using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Application.DTOs
{
    public class UserUpdateDto 
    {
        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}