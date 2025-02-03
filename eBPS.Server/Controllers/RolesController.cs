using eBPS.Application.Services.Shared;
using Microsoft.AspNetCore.Mvc;

namespace eBPS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _roleService.GetActiveRoles();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
