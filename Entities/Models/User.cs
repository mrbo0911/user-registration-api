using System;

namespace Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }    // Primary key
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? PinHash { get; set; }
        public bool IsMigrated { get; set; }
        public bool HasAcceptedPrivacyPolicy { get; set; }
        public bool HasCompletedOnboarding { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
