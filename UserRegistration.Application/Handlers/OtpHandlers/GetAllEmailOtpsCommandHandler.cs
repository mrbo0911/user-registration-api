using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.OtpCommands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.OtpHandlers
{
    public class GetAllEmailOtpsCommandHandler : IRequestHandler<GetAllEmailOtpsCommand, IActionResult>
    {
        private readonly IEmailOtpRepository _repository;

        public GetAllEmailOtpsCommandHandler(IEmailOtpRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(GetAllEmailOtpsCommand request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllEmailOtpsAsync();
            return new OkObjectResult(users);
        }
    }
}
