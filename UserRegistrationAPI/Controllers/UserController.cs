using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserRegistration.Application.Commands;
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

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            return await _mediator.Send(new GetUserByIdCommand(id));
        }

        [HttpGet("byIc/{icNumber}")]
        public async Task<IActionResult> GetUserByIcNumber(string icNumber)
        {
            return await _mediator.Send(new GetUserByIcNumberCommand(icNumber));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]UserRegisterDto userDto)
        {
            if (userDto == null)
                return BadRequest("User object is null");

            if (!ModelState.IsValid)
                return BadRequest("Invalid model object");

            return await _mediator.Send(new RegisterUserCommand(userDto));
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
    }
}