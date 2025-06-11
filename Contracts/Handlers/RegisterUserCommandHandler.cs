using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IActionResult>
    {
        private readonly IUserRepository _repository;

        public RegisterUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
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
            //await _repository.SaveAsync();


            // If the user is created successfully, acquire the OTP by calling to 3rd party service
            // For now, we will just return the created user entity
            // This is a placeholder for the OTP sending logic
            // await _otpService.SendOtpAsync(userEntity.PhoneNumber);

            return new CreatedAtActionResult("GetUserByIcNumber", "User", new { icNumber = user.IcNumber }, user);
        }
    }
}
