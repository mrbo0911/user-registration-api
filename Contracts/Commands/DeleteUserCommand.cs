using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands
{
    public record DeleteUserCommand(string IcNumber) : IRequest<IActionResult>;
}