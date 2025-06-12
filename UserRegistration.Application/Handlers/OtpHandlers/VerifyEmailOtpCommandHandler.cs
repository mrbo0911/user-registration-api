using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.OtpCommands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.OtpHandlers
{
    public class VerifyEmailOtpCommandHandler : IRequestHandler<VerifyEmailOtpCommand, IActionResult>
    {
        private readonly IEmailOtpRepository _repository;

        public VerifyEmailOtpCommandHandler(IEmailOtpRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(VerifyEmailOtpCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var dbOtp = await _repository.GetEmailOtpByIcNumberAsync(dto.IcNumber);
            if (dbOtp == null)
                return new NotFoundResult();

            // Verify the OTP by calling 3-rd party service
            // For now, we will just check if the OTP matches a hardcoded value for demonstration purposes
            if (dbOtp.Code != dto.Code)
                return new BadRequestObjectResult("Invalid OTP code.");

            // Update the OTP in the database
            dbOtp.SentAt = System.DateTime.UtcNow;
            dbOtp.IsVerified = true;

            await _repository.UpdateEmailOtpAsync(dbOtp);
            return new NoContentResult();
        }
    }
}
