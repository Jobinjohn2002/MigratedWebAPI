using Microsoft.AspNetCore.Mvc;
using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace SynergyApplicationFrameworkApi.Controllers
{
    /// <summary>
    /// Controller for handling service requirement details.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequirementDetailController : ControllerBase
    {
        private readonly ILogger<ServiceRequirementDetailController> _logger;
        private readonly IServiceRequirementDetailService _serviceRequirementDetailService; // Assuming you have a service

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequirementDetailController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceRequirementDetailService">The service for handling service requirement details.</param>
        public ServiceRequirementDetailController(ILogger<ServiceRequirementDetailController> logger, IServiceRequirementDetailService serviceRequirementDetailService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceRequirementDetailService = serviceRequirementDetailService ?? throw new ArgumentNullException(nameof(serviceRequirementDetailService));
        }

        /// <summary>
        /// Retrieves all service requirement details.
        /// </summary>
        /// <returns>An ActionResult containing a collection of service requirement details.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ServiceRequirementDetailDto>>> GetAllServiceRequirementDetails()
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve all service requirement details.");
                var details = await _serviceRequirementDetailService.GetAllAsync();
                _logger.LogInformation("Successfully retrieved all service requirement details.");
                return Ok(details);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all service requirement details.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Retrieves a specific service requirement detail by its ID.
        /// </summary>
        /// <param name="id">The ID of the service requirement detail to retrieve.</param>
        /// <returns>An ActionResult containing the service requirement detail, or NotFound if not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceRequirementDetailDto>> GetServiceRequirementDetailById(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve service requirement detail with ID: {Id}", id);
                var detail = await _serviceRequirementDetailService.GetByIdAsync(id);

                if (detail == null)
                {
                    _logger.LogWarning("Service requirement detail with ID: {Id} not found.", id);
                    return NotFound();
                }

                _logger.LogInformation("Successfully retrieved service requirement detail with ID: {Id}", id);
                return Ok(detail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving service requirement detail with ID: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Creates a new service requirement detail.
        /// </summary>
        /// <param name="detailDto">The DTO containing the data for the new service requirement detail.</param>
        /// <returns>An ActionResult containing the created service requirement detail, or BadRequest if the model is invalid.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceRequirementDetailDto>> CreateServiceRequirementDetail([FromBody] ServiceRequirementDetailDto detailDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating service requirement detail.");
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Attempting to create a new service requirement detail.");
                var createdDetail = await _serviceRequirementDetailService.CreateAsync(detailDto);
                _logger.LogInformation("Successfully created a new service requirement detail with ID: {Id}", createdDetail.ServiceRequirementId);
                return CreatedAtAction(nameof(GetServiceRequirementDetailById), new { id = createdDetail.ServiceRequirementId }, createdDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new service requirement detail.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Updates an existing service requirement detail.
        /// </summary>
        /// <param name="id">The ID of the service requirement detail to update.</param>
        /// <param name="detailDto">The DTO containing the updated data for the service requirement detail.</param>
        /// <returns>An ActionResult indicating success (NoContent) or failure (BadRequest, NotFound).</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateServiceRequirementDetail(int id, [FromBody] ServiceRequirementDetailDto detailDto)
        {
            if (id != detailDto.ServiceRequirementId)
            {
                _logger.LogWarning("ID mismatch: ID in route ({RouteId}) does not match ID in body ({BodyId}).", id, detailDto.ServiceRequirementId);
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for updating service requirement detail with ID: {Id}.", id);
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Attempting to update service requirement detail with ID: {Id}.", id);
                var existingDetail = await _serviceRequirementDetailService.GetByIdAsync(id);
                if (existingDetail == null)
                {
                    _logger.LogWarning("Service requirement detail with ID: {Id} not found for update.", id);
                    return NotFound();
                }

                await _serviceRequirementDetailService.UpdateAsync(detailDto);
                _logger.LogInformation("Successfully updated service requirement detail with ID: {Id}.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating service requirement detail with ID: {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Deletes a service requirement detail by its ID.
        /// </summary>
        /// <param name="id">The ID of the service requirement detail to delete.</param>
        /// <returns>An ActionResult indicating success (NoContent) or failure (NotFound).</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteServiceRequirementDetail(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to delete service requirement detail with ID: {Id}.", id);
                var existingDetail = await _serviceRequirementDetailService.GetByIdAsync(id);
                if (existingDetail == null)
                {
                    _logger.LogWarning("Service requirement detail with ID: {Id} not found for deletion.", id);
                    return NotFound();
                }

                await _serviceRequirementDetailService.DeleteAsync(id);
                _logger.LogInformation("Successfully deleted service requirement detail with ID: {Id}.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting service requirement detail with ID: {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
