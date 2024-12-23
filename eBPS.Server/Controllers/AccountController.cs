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
        public AccountController(IUserService userService) 
        {
            _userService = userService;
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
    }
}
