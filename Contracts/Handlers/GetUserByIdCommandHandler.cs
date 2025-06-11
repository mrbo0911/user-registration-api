using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers
{
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, IActionResult>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByIdAsync(request.Id);
            return user == null ? new NotFoundResult() : new OkObjectResult(user);
        }
    }
}
