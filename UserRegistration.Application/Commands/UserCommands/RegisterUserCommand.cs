using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Application.DTOs;

namespace UserRegistration.Application.Commands.UserCommands
{
    public record RegisterUserCommand(UserRegisterDto Dto) : IRequest<IActionResult>;
}
