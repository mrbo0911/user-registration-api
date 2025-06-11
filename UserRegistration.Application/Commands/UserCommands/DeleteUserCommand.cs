using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands.UserCommands
{
    public record DeleteUserCommand(string IcNumber) : IRequest<IActionResult>;
}