using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.UserCommands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.UserHandlers
{
    public class EnableBiometricCommandHandler : IRequestHandler<EnableBiometricCommand, IActionResult>
    {
        private readonly IUserRepository _repository;

        public EnableBiometricCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(EnableBiometricCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByIcNumberAsync(request.IcNumber);
            if (user == null)
                return new NotFoundResult();

            // Process biometric enablement logic here

            // Update the user entity to reflect that biometric has been enabled
            user.HasCompletedOnboarding = true;
            await _repository.EnableBiometric(user);

            return new OkResult();
        }
    }
}
