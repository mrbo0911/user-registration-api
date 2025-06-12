using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.OtpCommands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.UserHandlers
{
    public class GetPhoneOtpByIcNumberCommandHandler : IRequestHandler<GetPhoneOtpByIcNumberCommand, IActionResult>
    {
        private readonly IPhoneOtpRepository _repository;

        public GetPhoneOtpByIcNumberCommandHandler(IPhoneOtpRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(GetPhoneOtpByIcNumberCommand request, CancellationToken cancellationToken)
        {
            var icNumber = request.IcNumber;
            var otps = await _repository.GetPhoneOtpByIcNumberAsync(icNumber);
            return new OkObjectResult(otps);
        }
    }
}
