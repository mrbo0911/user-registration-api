using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands.UserCommands
{
    public record LoginCommand(string IcNumber) : IRequest<IActionResult>;
}
