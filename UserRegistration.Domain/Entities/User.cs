using System;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Domain.Entities
{
    public class User
    {
        [Key]
        [Required]
        public string IcNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public string? PinHash { get; set; }
        public bool IsMigrated { get; set; }
        public bool HasAcceptedPrivacyPolicy { get; set; }
        public bool HasCompletedOnboarding { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
