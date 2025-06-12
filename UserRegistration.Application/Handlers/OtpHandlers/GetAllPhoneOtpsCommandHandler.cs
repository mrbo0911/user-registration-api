using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.OtpCommands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.OtpHandlers
{
    public class GetAllPhoneOtpsCommandHandler : IRequestHandler<GetAllPhoneOtpsCommand, IActionResult>
    {
        private readonly IPhoneOtpRepository _repository;

        public GetAllPhoneOtpsCommandHandler(IPhoneOtpRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(GetAllPhoneOtpsCommand request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllPhoneOtpsAsync();
            return new OkObjectResult(users);
        }
    }
}
