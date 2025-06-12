using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands.OtpCommands
{
    public record GetAllPhoneOtpsCommand() : IRequest<IActionResult>;
}
