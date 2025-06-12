using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.OtpCommands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.UserHandlers
{
    public class GetEmailOtpByIcNumberCommandHandler : IRequestHandler<GetEmailOtpByIcNumberCommand, IActionResult>
    {
        private readonly IEmailOtpRepository _repository;

        public GetEmailOtpByIcNumberCommandHandler(IEmailOtpRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(GetEmailOtpByIcNumberCommand request, CancellationToken cancellationToken)
        {
            var icNumber = request.IcNumber;
            var otps = await _repository.GetEmailOtpByIcNumberAsync(icNumber);
            return new OkObjectResult(otps);
        }
    }
}
