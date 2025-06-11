using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserRegistrationAPI.DTOs;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByUserId(Guid id)
        {
            try {
                User user = await _repository.User.GetUserById(id);

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
        public IActionResult CreateUser([FromBody]UserRegisterDto userDto)
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

                var userEntity = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    Phone = userDto.Phone,
                    CreatedAt = DateTime.UtcNow,
                    IsMigrated = false,
                    HasAcceptedPrivacyPolicy = false,
                    HasCompletedOnboarding = false
                };

                _repository.User.CreateUser(userEntity);
                _repository.Save();

                return CreatedAtAction(nameof(GetUserByUserId), new { id = userEntity.Id }, userEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody]User user)
        {
            try {
                if (user == null) {
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid) {
                    return BadRequest("Invalid model object");
                }

                var dbUser = await _repository.User.GetUserById(id);
                if (dbUser == null) {
                    return NotFound();
                }

                dbUser.CreatedAt = DateTime.Now;
                await _repository.User.UpdateUser(dbUser, user);

                return NoContent();
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try {
                User user = await _repository.User.GetUserById(id);
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