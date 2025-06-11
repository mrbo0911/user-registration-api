using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands
{
    public record GetAllUsersCommand() : IRequest<IActionResult>;
}
