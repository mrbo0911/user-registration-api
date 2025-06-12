using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands.OtpCommands
{
    public record GetEmailOtpByIcNumberCommand(string IcNumber) : IRequest<IActionResult>;
}