using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserRegistrationAPI.DTOs;

namespace UserRegistrationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            try {
                var users = await _repository.User.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                User user = await _repository.User.GetUserById(id);

                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("byIc/{icNumber}")]
        public async Task<IActionResult> GetUserByIcNumber(string icNumber)
        {
            try {
                User user = await _repository.User.GetUserByIcNumber(icNumber);

                if (user == null) {
                    return NotFound();
                }
                else {
                    return Ok(user);
                }
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody]UserRegisterDto userDto)
        {
            try
            {
                if (userDto == null)
                {
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                // check whether user already exists
                var existingUser = _repository.User.GetUserByIcNumber(userDto.IcNumber).Result;
                if (existingUser != null)
                {
                    return Conflict("There is account registered with the IC number. Please login to continue.");
                }

                var userEntity = new User
                {
                    Id = Guid.NewGuid(),
                    IcNumber = userDto.IcNumber,
                    UserName = userDto.UserName,
                    PhoneNumber = userDto.PhoneNumber,
                    EmailAddress = userDto.EmailAddress,
                    CreatedAt = DateTime.UtcNow,
                    IsMigrated = false,
                    HasAcceptedPrivacyPolicy = false,
                    HasCompletedOnboarding = false
                };

                _repository.User.CreateUser(userEntity);
                _repository.Save();

                // If the user is created successfully, acquire the OTP by calling to 3rd party service
                // For now, we will just return the created user entity
                // This is a placeholder for the OTP sending logic
                // await _otpService.SendOtpAsync(userEntity.PhoneNumber);

                return CreatedAtAction(nameof(GetUserById), new { id = userEntity.Id }, userEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{icNumber}")]
        public async Task<IActionResult> UpdateUser(string icNumber, [FromBody]UserUpdateDto user)
        {
            try {
                if (user == null) {
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid) {
                    return BadRequest("Invalid model object");
                }

                var dbUser = await _repository.User.GetUserByIcNumber(icNumber);
                if (dbUser == null) {
                    return NotFound();
                }

                var userEntity = new User
                {
                    IcNumber = icNumber,
                    UserName = user.UserName,
                    EmailAddress = user.Email,
                    PhoneNumber = user.Phone,
                    IsMigrated = dbUser.IsMigrated,
                    HasAcceptedPrivacyPolicy = dbUser.HasAcceptedPrivacyPolicy,
                    HasCompletedOnboarding = dbUser.HasCompletedOnboarding,
                    CreatedAt = DateTime.Now
                };

                await _repository.User.UpdateUser(dbUser, userEntity);

                return NoContent();
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{icNumber}")]
        public async Task<IActionResult> DeleteUser(string icNumber)
        {
            try {
                User user = await _repository.User.GetUserByIcNumber(icNumber);
                if (user == null) {
                    return NotFound();
                }

                await _repository.User.DeleteUser(user);

                return NoContent();
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}