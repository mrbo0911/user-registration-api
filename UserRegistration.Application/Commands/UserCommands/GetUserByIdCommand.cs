using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UserRegistration.Application.Commands.UserCommands
{
    public record GetUserByIdCommand(Guid Id) : IRequest<IActionResult>;
}