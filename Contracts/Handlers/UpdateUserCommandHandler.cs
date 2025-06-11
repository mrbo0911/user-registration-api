using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IActionResult>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var dbUser = await _repository.GetUserByIcNumberAsync(request.IcNumber);
            if (dbUser == null)
                return new NotFoundResult();

            var updatedUser = new User
            {
                IcNumber = request.IcNumber,
                UserName = dto.UserName,
                EmailAddress = dto.Email,
                PhoneNumber = dto.Phone,
                IsMigrated = dbUser.IsMigrated,
                HasAcceptedPrivacyPolicy = dbUser.HasAcceptedPrivacyPolicy,
                HasCompletedOnboarding = dbUser.HasCompletedOnboarding,
                CreatedAt = dbUser.CreatedAt
            };

            await _repository.UpdateUser(dbUser, updatedUser);
            return new NoContentResult();
        }
    }
}
