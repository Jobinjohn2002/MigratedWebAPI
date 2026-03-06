using Microsoft.AspNetCore.Mvc;
using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace SynergyApplicationFrameworkApi.Controllers
{
    /// <summary>
    /// Controller for managing Service Requirements.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequirementController : ControllerBase
    {
        private readonly ILogger<ServiceRequirementController> _logger;
        private readonly IServiceRequirementService _serviceRequirementService; // Assuming you have a service

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequirementController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceRequirementService">The service requirement service.</param>
        public ServiceRequirementController(ILogger<ServiceRequirementController> logger, IServiceRequirementService serviceRequirementService)
        {
            _logger = logger;
            _serviceRequirementService = serviceRequirementService;
        }

        /// <summary>
        /// Retrieves all service requirements.
        /// </summary>
        /// <returns>An ActionResult containing a list of ServiceRequirementDTOs.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ServiceRequirementDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ServiceRequirementDTO>>> GetAllServiceRequirements()
        {
            try
            {
                _logger.LogInformation("Getting all service requirements.");
                var serviceRequirements = await _serviceRequirementService.GetAllServiceRequirementsAsync();
                return Ok(serviceRequirements);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all service requirements.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Retrieves a service requirement by its ID.
        /// </summary>
        /// <param name="id">The ID of the service requirement to retrieve.</param>
        /// <returns>An ActionResult containing the ServiceRequirementDTO if found, otherwise NotFound.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServiceRequirementDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceRequirementDTO>> GetServiceRequirementById(int id)
        {
            try
            {
                _logger.LogInformation("Getting service requirement with ID: {Id}", id);
                var serviceRequirement = await _serviceRequirementService.GetServiceRequirementByIdAsync(id);

                if (serviceRequirement == null)
                {
                    _logger.LogWarning("Service requirement with ID: {Id} not found.", id);
                    return NotFound();
                }

                return Ok(serviceRequirement);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting service requirement with ID: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Creates a new service requirement.
        /// </summary>
        /// <param name="serviceRequirementDto">The ServiceRequirementDTO containing the data for the new service requirement.</param>
        /// <returns>An ActionResult containing the created ServiceRequirementDTO.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ServiceRequirementDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceRequirementDTO>> CreateServiceRequirement([FromBody] ServiceRequirementDTO serviceRequirementDto)
        {
            if (serviceRequirementDto == null)
            {
                _logger.LogError("Invalid request: ServiceRequirementDTO is null.");
                return BadRequest("ServiceRequirementDTO cannot be null.");
            }

            try
            {
                _logger.LogInformation("Creating a new service requirement.");
                var createdServiceRequirement = await _serviceRequirementService.CreateServiceRequirementAsync(serviceRequirementDto);

                return CreatedAtAction(nameof(GetServiceRequirementById), new { id = createdServiceRequirement.Id }, createdServiceRequirement);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating a new service requirement.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Updates an existing service requirement.
        /// </summary>
        /// <param name="id">The ID of the service requirement to update.</param>
        /// <param name="serviceRequirementDto">The ServiceRequirementDTO containing the updated data.</param>
        /// <returns>An ActionResult indicating success (NoContent) or failure (NotFound, BadRequest).</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateServiceRequirement(int id, [FromBody] ServiceRequirementDTO serviceRequirementDto)
        {
            if (serviceRequirementDto == null)
            {
                _logger.LogError("Invalid request: ServiceRequirementDTO is null.");
                return BadRequest("ServiceRequirementDTO cannot be null.");
            }

            if (id != serviceRequirementDto.Id)
            {
                _logger.LogError("Invalid request: ID in route does not match ID in body.");
                return BadRequest("ID in route does not match ID in body.");
            }

            try
            {
                _logger.LogInformation("Updating service requirement with ID: {Id}", id);
                var existingServiceRequirement = await _serviceRequirementService.GetServiceRequirementByIdAsync(id);
                if (existingServiceRequirement == null)
                {
                    _logger.LogWarning("Service requirement with ID: {Id} not found.", id);
                    return NotFound();
                }

                await _serviceRequirementService.UpdateServiceRequirementAsync(serviceRequirementDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating service requirement with ID: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Deletes a service requirement by its ID.
        /// </summary>
        /// <param name="id">The ID of the service requirement to delete.</param>
        /// <returns>An ActionResult indicating success (NoContent) or failure (NotFound).</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteServiceRequirement(int id)
        {
            try
            {
                _logger.LogInformation("Deleting service requirement with ID: {Id}", id);
                var existingServiceRequirement = await _serviceRequirementService.GetServiceRequirementByIdAsync(id);
                if (existingServiceRequirement == null)
                {
                    _logger.LogWarning("Service requirement with ID: {Id} not found.", id);
                    return NotFound();
                }

                await _serviceRequirementService.DeleteServiceRequirementAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting service requirement with ID: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
