using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Application.DTOs;

namespace UserRegistration.Application.Commands.OtpCommands
{
    public record VerifyEmailOtpCommand(EmailOtpDto Dto) : IRequest<IActionResult>;
}