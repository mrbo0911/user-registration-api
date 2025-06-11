using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.DTOs
{
    public class UserRegisterDto 
    {
        [Required]
        public string IcNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }
    }
}