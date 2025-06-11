//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Threading.Tasks;
//using UserRegistration.Application.Commands.OtpCommands;
//using UserRegistration.Application.DTOs;

//namespace UserRegistrationAPI.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class OtpController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public OtpController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [HttpPost("verify")]
//        public IActionResult Verify([FromBody] OtpDto dto)
//        {
//            var otp = _context.Otps
//                .Where(o => o.Phone == dto.Phone && o.Code == dto.Code && !o.IsVerified)
//                .OrderByDescending(o => o.SentAt)
//                .FirstOrDefault();

//            if (otp == null)
//                return BadRequest("Invalid or expired OTP");

//            if (otp.IsExpired)
//                return BadRequest("OTP has expired");

//            otp.IsVerified = true;
//            _context.SaveChanges();
//            return Ok("OTP verified");
//        }

//        [HttpDelete("cleanup")]
//        public IActionResult CleanupExpiredOtps()
//        {
//            var expiredOtps = _context.Otps.Where(o => o.IsExpired && !o.IsVerified).ToList();
//            _context.Otps.RemoveRange(expiredOtps);
//            _context.SaveChanges();
//            return Ok($"Deleted {expiredOtps.Count} expired OTPs");
//        }
//    }
//}
