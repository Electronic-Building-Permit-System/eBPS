using eBPS.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace eBPS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("get-building-purpose")]
        public async Task<IActionResult> GetActiveBuildingPurpose()
        {
            try
            {
                var buildingPurpose = await _applicationService.GetActiveBuildingPurpose();
                return Ok(buildingPurpose);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("get-structure-type")]
        public async Task<IActionResult> GetActiveStructureType()
        {
            try
            {
                var structureType = await _applicationService.GetActiveStructureType();
                return Ok(structureType);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
