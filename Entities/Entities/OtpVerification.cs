using System;

namespace UserRegistration.Domain.Entities
{
    public class OtpVerification
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsVerified { get; set; }

        public DateTime ExpiresAt => SentAt.AddMinutes(3);
        public bool IsExpired => DateTime.UtcNow > ExpiresAt;
    }
}
