using UserRegistrationAPI.DTOs;

namespace UserRegistration.Application.Commands
{
    public record RegisterUserCommand(UserRegisterDto Dto) : IRequest<IActionResult>;
}
