using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.PinCommands;
using UserRegistration.Domain.Interfaces;
using System.Security.Cryptography;

namespace UserRegistration.Application.Handlers.PinHandlers
{
    public class CreatePinCommandHandler : IRequestHandler<CreatePinCommand, IActionResult>
    {
        private readonly IUserRepository _repository;

        public CreatePinCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        private static string HashPin(string pin)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(pin);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public async Task<IActionResult> Handle(CreatePinCommand request, CancellationToken cancellationToken)
        {
            if (request.Pin != request.ConfirmPin)
                return new BadRequestObjectResult("PINs do not match");

            var user = await _repository.GetUserByIcNumberAsync(request.IcNumber);
            if (user == null)
                return new NotFoundResult();

            user.PinHash = HashPin(request.Pin);
            await _repository.CreatePin(user);

            return new OkResult();
        }
    }
}
