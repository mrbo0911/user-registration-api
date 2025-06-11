using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.UserCommands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers.UserHandlers
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, IActionResult>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllUsers();
            return new OkObjectResult(users);
        }
    }
}
