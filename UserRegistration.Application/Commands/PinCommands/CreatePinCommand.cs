using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Application.Commands.PinCommands
{
    public record CreatePinCommand(string IcNumber, string Pin, string ConfirmPin) : IRequest<IActionResult>;
}
