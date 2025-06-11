using System;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Domain.Entities
{
    public class Otp
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Code { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsVerified { get; set; }

        public DateTime ExpiresAt;
        public bool IsExpired { get; set; }
    }
}
