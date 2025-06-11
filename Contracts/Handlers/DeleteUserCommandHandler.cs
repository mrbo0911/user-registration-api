using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserRegistration.Application.Commands;
using UserRegistration.Domain.Interfaces;

namespace UserRegistration.Application.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IActionResult>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByIcNumberAsync(request.IcNumber);
            if (user == null)
                return new NotFoundResult();

            await _repository.DeleteUser(user);
            return new NoContentResult();
        }
    }
}
