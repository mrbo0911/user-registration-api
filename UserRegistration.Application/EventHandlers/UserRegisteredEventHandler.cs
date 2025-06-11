using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Events;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.EventHandlers
{
    public class UserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
    {
        private readonly IOtpRepository _otpRepository;

        public UserRegisteredEventHandler(IOtpRepository otpRepository)
        {
            _otpRepository = otpRepository;
        }

        public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"OTP {notification.OtpCode} sent to {notification.User.PhoneNumber}");

            // Storing the OTP
            var otp = new Domain.Entities.Otp
            {
                PhoneNumber = notification.User.PhoneNumber,
                Code = notification.OtpCode
            };

            await _otpRepository.CreateOtpAsync(otp);
        }
    }
}
