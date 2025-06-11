using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.UserCommands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.UserHandlers
{
    public class GetUserByIcNumberCommandHandler : IRequestHandler<GetUserByIcNumberCommand, IActionResult>
    {
        private readonly IUserRepository _repository;

        public GetUserByIcNumberCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(GetUserByIcNumberCommand request, CancellationToken cancellationToken)
        {
            var icNumber = request.IcNumber;
            var users = await _repository.GetUserByIcNumberAsync(icNumber);
            return new OkObjectResult(users);
        }
    }
}
