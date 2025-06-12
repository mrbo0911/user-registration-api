using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Events;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.EventHandlers
{
    public class EmailOtpEventHandler : INotificationHandler<UserRegisteredEvent>
    {
        private readonly IEmailOtpRepository _otpRepository;

        public EmailOtpEventHandler(IEmailOtpRepository otpRepository)
        {
            _otpRepository = otpRepository;
        }

        public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"OTP {notification.EmailOtp} sent to {notification.User.EmailAddress}");

            // Checking if the user already has an OTP
            var existingOtp = await _otpRepository.GetEmailOtpByIcNumberAsync(notification.User.IcNumber);
            if (existingOtp != null)
            {
                Console.WriteLine($"User {notification.User.IcNumber} already has an OTP.");

                existingOtp.Code = notification.EmailOtp;
                existingOtp.SentAt = DateTime.UtcNow;
                existingOtp.IsVerified = false;
                await _otpRepository.UpdateEmailOtpAsync(existingOtp);
            }
            else
            {
                Console.WriteLine($"Creating new OTP for user {notification.User.IcNumber}");

                // Storing the OTP
                var otp = new Domain.Entities.EmailOtp
                {
                    IcNumber = notification.User.IcNumber,
                    Code = notification.EmailOtp,
                    SentAt = DateTime.UtcNow,
                    IsVerified = false,
                };

                await _otpRepository.CreateEmailOtpAsync(otp);
            }
        }
    }
}
