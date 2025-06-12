using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.UserCommands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.UserHandlers
{
    public class ConsentPrivacyCommandHandler : IRequestHandler<ConsentPrivacyCommand, IActionResult>
    {
        private readonly IUserRepository _repository;

        public ConsentPrivacyCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(ConsentPrivacyCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByIcNumberAsync(request.IcNumber);
            if (user == null)
                return new NotFoundResult();

            user.HasAcceptedPrivacyPolicy = true;
            await _repository.AcceptConsentPrivacy(user);

            return new OkResult();
        }
    }
}
