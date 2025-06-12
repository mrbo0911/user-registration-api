using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Events;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.EventHandlers
{
    public class PhoneOtpEventHandler : INotificationHandler<UserRegisteredEvent>
    {
        private readonly IPhoneOtpRepository _otpRepository;

        public PhoneOtpEventHandler(IPhoneOtpRepository otpRepository)
        {
            _otpRepository = otpRepository;
        }

        public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"OTP {notification.PhoneOtp} sent to {notification.User.PhoneNumber}");

            // Checking if the user already has an OTP
            var existingOtp = await _otpRepository.GetPhoneOtpByIcNumberAsync(notification.User.IcNumber);
            if (existingOtp != null) {
                Console.WriteLine($"User {notification.User.IcNumber} already has an OTP.");

                existingOtp.Code = notification.PhoneOtp;
                existingOtp.SentAt = DateTime.UtcNow;
                existingOtp.IsVerified = false;
                await _otpRepository.UpdatePhoneOtpAsync(existingOtp);
            }
            else
            {
                Console.WriteLine($"Creating new OTP for user {notification.User.IcNumber}");

                var otp = new Domain.Entities.PhoneOtp
                {
                    IcNumber = notification.User.IcNumber,
                    Code = notification.PhoneOtp,
                    SentAt = DateTime.UtcNow,
                    IsVerified = false,
                };

                await _otpRepository.CreatePhoneOtpAsync(otp);
            }
        }
    }
}
