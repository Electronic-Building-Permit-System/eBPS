using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces;
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
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        
        [HttpGet("get-landscape-type")]
        public async Task<IActionResult> GetActiveLandscapeType()
        {
            try
            {
                var landscapetype = await _applicationService.GetActiveLandscapeType();
                return Ok(landscapetype);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("get-issue-district")]
        public async Task<IActionResult> GetActiveIssueDistrict()
        {
            try
            {
                var issuedistrict = await _applicationService.GetActiveIssueDistrict();
                return Ok(issuedistrict);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("get-transaction-type")]
        public async Task<IActionResult> GetActiveTransactionType()
        {
            try
            {
                var transactiontype = await _applicationService.GetActiveTransactionType();
                return Ok(transactiontype);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        //For Building Application Form
        [HttpGet("get-building-application-list")]
        public async Task<IActionResult> GetBuildingApplicationList()
        {
            try
            {
                var buildingApplicationList = await _applicationService.GetBuildingApplicationList();
                return Ok(buildingApplicationList);
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
                return Created("", new { Message = "Application registered successfully." });
            }

            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });

            }
        }

        [HttpPut("edit-building-application/{id}")]
        public async Task<IActionResult> EditBuildingApplication(int id, [FromBody] BuildingApplicationDTO buildingApplicationDTO)
        {
            try
            {
                // Pass the ID and updated DTO to the service layer for processing
                await _applicationService.EditBuildingApplication(id, buildingApplicationDTO);
                return Ok(new { Message = "Application updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
