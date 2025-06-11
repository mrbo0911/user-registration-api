using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands.UserCommands
{
    public record GetUserByIcNumberCommand(string IcNumber) : IRequest<IActionResult>;
}