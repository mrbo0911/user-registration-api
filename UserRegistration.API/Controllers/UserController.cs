using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.PinCommands;
using UserRegistration.Application.Commands.UserCommands;
using UserRegistration.Application.DTOs;

namespace UserRegistrationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsersCommand());
        }

        [HttpGet("{icNumber}")]
        public async Task<IActionResult> GetUserByIcNumber(string icNumber)
        {
            return await _mediator.Send(new GetUserByIcNumberCommand(icNumber));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]UserRegisterDto userDto)
        {
            if (userDto == null || !ModelState.IsValid)
                return BadRequest("Invalid user input");

            return await _mediator.Send(new RegisterUserCommand(userDto));
        }

        [HttpPost("consentPrivacy")]
        public async Task<IActionResult> ConsentPrivacy([FromQuery]string icNumber)
        {
            return await _mediator.Send(new ConsentPrivacyCommand(icNumber));
        }

        [HttpPost("createPin")]
        public async Task<IActionResult> CreatePin([FromQuery]string icNumber, [FromQuery]string pin, [FromQuery]string confirmPin)
        {
            return await _mediator.Send(new CreatePinCommand(icNumber, pin, confirmPin));
        }

        [HttpPost("enableBiometric")]
        public async Task<IActionResult> EnableBiometric([FromQuery] string icNumber)
        {
            return await _mediator.Send(new EnableBiometricCommand(icNumber));
        }

        [HttpPut("{icNumber}")]
        public async Task<IActionResult> UpdateUser(string icNumber, [FromBody]UserUpdateDto user)
        {
            if (user == null || !ModelState.IsValid)
                return BadRequest("Invalid user input");

            return await _mediator.Send(new UpdateUserCommand(icNumber, user));
        }

        [HttpDelete("{icNumber}")]
        public async Task<IActionResult> DeleteUser(string icNumber)
        {
            return await _mediator.Send(new DeleteUserCommand(icNumber));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] string icNumber)
        {
            return await _mediator.Send(new LoginCommand(icNumber));
        }
    }
}