using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistration.Domain.Entities
{
    public class EmailOtp
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string IcNumber { get; set; }

        [Required]
        public int Code { get; set; }

        public DateTime SentAt { get; set; }
        public bool IsVerified { get; set; }
        public DateTime ExpiresAt;
        public bool IsExpired { get; set; }
    }
}
