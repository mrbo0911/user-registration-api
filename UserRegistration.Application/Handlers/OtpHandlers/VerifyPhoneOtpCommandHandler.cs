using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.OtpCommands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.OtpHandlers
{
    public class VerifyPhoneOtpCommandHandler : IRequestHandler<VerifyPhoneOtpCommand, IActionResult>
    {
        private readonly IPhoneOtpRepository _repository;

        public VerifyPhoneOtpCommandHandler(IPhoneOtpRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(VerifyPhoneOtpCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var dbOtp = await _repository.GetPhoneOtpByIcNumberAsync(dto.IcNumber);
            if (dbOtp == null)
                return new NotFoundResult();

            // Verify the OTP by calling 3-rd party service
            // For now, we will just check if the OTP matches a hardcoded value for demonstration purposes
            if (dbOtp.Code != dto.Code)
                return new BadRequestObjectResult("Invalid OTP code.");

            dbOtp.SentAt = System.DateTime.UtcNow;
            dbOtp.IsVerified = true;

            await _repository.UpdatePhoneOtpAsync(dbOtp);
            return new NoContentResult();
        }
    }
}
