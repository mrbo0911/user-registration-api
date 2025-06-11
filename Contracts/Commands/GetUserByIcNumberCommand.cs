using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands
{
    public record GetUserByIcNumberCommand(string IcNumber) : IRequest<IActionResult>;
}