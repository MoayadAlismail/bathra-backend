using Bathra.Application.DTOs;
using Bathra.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bathra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                return BadRequest(ApiResponse<object>.ErrorResponse(
                    "Validation failed", 
                    HttpStatusCode.BadRequest,
                    errors));
            }

            var result = await _userService.RegisterUserAsync(userDto);

            if (result)
                return Ok(ApiResponse<object>.SuccessResponse(
                    new { },
                    "User registered successfully"));
            else
                return StatusCode(500, ApiResponse<object>.ErrorResponse(
                    "An error occurred while registering the user",
                    HttpStatusCode.InternalServerError,
                    new[] { "User registration failed" }));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                return BadRequest(ApiResponse<object>.ErrorResponse(
                    "Validation failed",
                    HttpStatusCode.BadRequest,
                    errors));
            }

            var result = await _userService.LoginUserAsync(userDto);
            
            if (result.ResponseCode == HttpStatusCode.OK)
                return Ok(ApiResponse<UserLoginDto>.SuccessResponse(
                    result,
                    "Login successful"));
            else
                return Unauthorized(ApiResponse<object>.ErrorResponse(
                    "Invalid email or password", 
                    HttpStatusCode.Unauthorized));
        }
    }
}
