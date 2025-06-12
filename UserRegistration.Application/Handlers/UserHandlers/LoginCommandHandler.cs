using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.UserCommands;
using UserRegistration.Application.Events;
using UserRegistration.Domain.Interfaces;
using UserRegistration.Domain.Services;

namespace UserRegistration.Application.Handlers.UserHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, IActionResult>
    {
        private readonly IUserRepository _repository;
        private readonly IMediator _mediator;
        private readonly IOtpService _otpService;

        public LoginCommandHandler(IUserRepository repository, IMediator mediator, IOtpService otpService)
        {
            _repository = repository;
            _mediator = mediator;
            _otpService = otpService;
        }

        public async Task<IActionResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByIcNumberAsync(request.IcNumber);
            if (user == null)
                return new NotFoundObjectResult("User not found");

            // Simulate sending and returning a 4-digit OTP for demonstration/testing.
            var phoneOtp = await _otpService.GeneratePhoneOtpAsync(user.PhoneNumber, user.IcNumber);
            var emailOtp = await _otpService.GenerateEmailOtpAsync(user.EmailAddress, user.IcNumber);

            // Save the OTP in the database or cache for verification later
            await _mediator.Publish(new UserRegisteredEvent(user, phoneOtp, emailOtp), cancellationToken);

            var result = new
            {
                user = new
                {
                    user.IcNumber,
                    user.UserName,
                    user.PhoneNumber,
                    user.EmailAddress,
                    user.CreatedAt
                },
                phoneOtp,
                emailOtp
            };

            return new CreatedAtActionResult("GetUserByIcNumber", "User", new { icNumber = user.IcNumber }, result);
        }
    }
}
