using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands.OtpCommands
{
    public record GetPhoneOtpByIcNumberCommand(string IcNumber) : IRequest<IActionResult>;
}