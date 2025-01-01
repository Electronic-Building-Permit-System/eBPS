using eBPS.Application.DTOs;
using eBPS.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace eBPS.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public AccountController(IUserService userService, IEmailService emailService) 
        {
            _userService = userService;
            _emailService = emailService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userDto)
        {
            try
            {
                await _userService.RegisterUser(userDto);
                return Created("", new { Message = "User registered successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginDto)
        {
            try
            {
                var token = await _userService.LoginUser(loginDto);
                return Ok(new { Token = token, Message = "Login successful." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("forget-password")]
        public IActionResult ForgetPassword([FromBody] ForgetPasswordDTO request)
        {
            try
            {
                _emailService.SendEmail(request.To, request.Subject, request.Body);
                return Ok(new { message = "Email sent successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
    }
}
