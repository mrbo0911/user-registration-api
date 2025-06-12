using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserRegistration.Application.Commands.OtpCommands;
using UserRegistration.Application.DTOs;

namespace UserRegistrationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtpController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OtpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAllPhoneOtps")]
        public async Task<IActionResult> GetAllPhoneOtps()
        {
            return await _mediator.Send(new GetAllPhoneOtpsCommand());
        }

        [HttpGet("phone/{icNumber}")]
        public async Task<IActionResult> GetPhoneOtpByIcNumber(string icNumber)
        {
            return await _mediator.Send(new GetPhoneOtpByIcNumberCommand(icNumber));
        }

        [HttpGet("getAllEmailOtps")]
        public async Task<IActionResult> GetAllEmailOtps()
        {
            return await _mediator.Send(new GetAllEmailOtpsCommand());
        }

        [HttpGet("email/{icNumber}")]
        public async Task<IActionResult> GetEmailOtpByIcNumber(string icNumber)
        {
            return await _mediator.Send(new GetEmailOtpByIcNumberCommand(icNumber));
        }

        [HttpPost("verifyPhoneOtp")]
        public async Task<IActionResult> VerifyPhoneOtpAsync([FromBody]PhoneOtpDto dto)
        {
            return await _mediator.Send(new VerifyPhoneOtpCommand(dto));
        }

        [HttpPost("verifyEmailOtp")]
        public async Task<IActionResult> VerifyEmailOtpAsync([FromBody]EmailOtpDto dto)
        {
            return await _mediator.Send(new VerifyEmailOtpCommand(dto));
        }
    }
}
