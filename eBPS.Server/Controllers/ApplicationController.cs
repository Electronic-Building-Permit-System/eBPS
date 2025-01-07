using eBPS.Application.DTOs;
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
        [HttpGet("get-nbc-class")]
        public async Task<IActionResult> GetActiveNBCClass()
        {
            try
            {
                var nbcClass = await _applicationService.GetActiveNBCClass();
                return Ok(nbcClass);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost("create-building-application")]
        public async Task<IActionResult> CreateBuildingApplication([FromBody] BuildingApplicationDTO buildingApplicationDTO)
        {
            try
            {
                await _applicationService.CreateBuildingApplication(buildingApplicationDTO);
                return Created("", new { Message = "User registered successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });

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
        [HttpGet("get-building-application")]
        public async Task<IActionResult> GetActiveBuildingApplication()
        {
            try
            {
                var buildingApplication = await _applicationService.GetActiveBuildingApplication();
                return Ok(buildingApplication);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("get-ward")]
        public async Task<IActionResult> GetActiveWard()
        {
            try
            {
                var ward = await _applicationService.GetActiveWard();
                return Ok(ward);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("get-land-use-sub-zone")]
        public async Task<IActionResult> GetActiveLandUseSubZone()
        {
            try
            {
                var landUseSubZone = await _applicationService.GetActiveLandUseSubZone();
                return Ok(landUseSubZone);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("get-land-use-zone")]
        public async Task<IActionResult> GetActiveLandUseZone()
        {
            try
            {
                var landusezone = await _applicationService.GetActiveLandUseZone();
                return Ok(landusezone);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
