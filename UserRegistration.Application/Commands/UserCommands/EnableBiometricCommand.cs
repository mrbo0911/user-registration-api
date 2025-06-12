using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands.UserCommands
{
    public record EnableBiometricCommand(string IcNumber) : IRequest<IActionResult>;
}
