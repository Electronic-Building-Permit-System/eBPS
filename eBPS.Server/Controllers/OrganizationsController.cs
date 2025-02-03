using eBPS.Application.DTOs;
using eBPS.Application.Services.Shared;
using Microsoft.AspNetCore.Mvc;

namespace eBPS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizations()
        {
            try
            {
                var organizations = await _organizationService.GetActiveOrganizations();
                return Ok(organizations);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("user-organization")]
        public async Task<IActionResult> GetUserOrganizations()
        {
            try
            {
                var userId = _organizationService.GetUserIdFromToken(HttpContext);
                var organizations = await _organizationService.GetUserOrganizations(userId);
                return Ok(organizations);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
