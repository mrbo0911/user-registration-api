using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.UserCommands;
using UserRegistration.Application.Events;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.UserHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IActionResult>
    {
        private readonly IUserRepository _repository;
        private readonly IMediator _mediator;

        public RegisterUserCommandHandler(IUserRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<IActionResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var existingUser = await _repository.GetUserByIcNumberAsync(dto.IcNumber);
            if (existingUser != null)
                return new ConflictObjectResult("There is account registered with the IC number. Please login to continue.");

            var user = new User
            {
                IcNumber = dto.IcNumber,
                UserName = dto.UserName,
                PhoneNumber = dto.PhoneNumber,
                EmailAddress = dto.EmailAddress,
                CreatedAt = DateTime.UtcNow,
                IsMigrated = false,
                HasAcceptedPrivacyPolicy = false,
                HasCompletedOnboarding = false
            };

            await _repository.CreateUser(user);

            // If the user is created successfully, acquire the OTP by calling to 3rd party service  
            // For now, we will just return the created user entity  
            // This is a placeholder for the OTP sending logic  
            // await _otpService.SendOtpAsync(userEntity.PhoneNumber);

            // Simulate sending and returning a 4-digit OTP for demonstration/testing.
            var otp = new Random().Next(1000, 9999).ToString();

            // Save the OTP in the database or cache for verification later
            //await _otpRepository.SaveOtpAsync(userEntity.IcNumber, otp);

            await _mediator.Publish(new UserRegisteredEvent(user, otp), cancellationToken);

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
                otpCode = otp
            };

            return new CreatedAtActionResult("GetUserByIcNumber", "User", new { icNumber = user.IcNumber }, result);
        }
    }
}
