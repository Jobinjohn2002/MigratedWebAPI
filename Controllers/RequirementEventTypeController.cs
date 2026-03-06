using Microsoft.AspNetCore.Mvc;
using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace SynergyApplicationFrameworkApi.Controllers
{
    /// <summary>
    /// Controller for managing Service Requirement Event Types.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequirementEventTypeController : ControllerBase
    {
        private readonly ILogger<ServiceRequirementEventTypeController> _logger;
        private readonly IServiceRequirementEventTypeService _serviceRequirementEventTypeService; // Assuming you have a service

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequirementEventTypeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceRequirementEventTypeService">The service for managing Service Requirement Event Types.</param>
        public ServiceRequirementEventTypeController(ILogger<ServiceRequirementEventTypeController> logger, IServiceRequirementEventTypeService serviceRequirementEventTypeService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceRequirementEventTypeService = serviceRequirementEventTypeService ?? throw new ArgumentNullException(nameof(serviceRequirementEventTypeService));
        }

        /// <summary>
        /// Retrieves all Service Requirement Event Types.
        /// </summary>
        /// <returns>An ActionResult containing a collection of ServiceRequirementEventTypeDTOs.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ServiceRequirementEventTypeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ServiceRequirementEventTypeDTO>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all Service Requirement Event Types.");
                var serviceRequirementEventTypes = await _serviceRequirementEventTypeService.GetAllAsync();
                return Ok(serviceRequirementEventTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all Service Requirement Event Types.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Retrieves a Service Requirement Event Type by its ID.
        /// </summary>
        /// <param name="id">The ID of the Service Requirement Event Type to retrieve.</param>
        /// <returns>An ActionResult containing the ServiceRequirementEventTypeDTO, or NotFound if not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServiceRequirementEventTypeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceRequirementEventTypeDTO>> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Getting Service Requirement Event Type with ID: {Id}", id);
                var serviceRequirementEventType = await _serviceRequirementEventTypeService.GetByIdAsync(id);

                if (serviceRequirementEventType == null)
                {
                    _logger.LogWarning("Service Requirement Event Type with ID: {Id} not found.", id);
                    return NotFound();
                }

                return Ok(serviceRequirementEventType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Service Requirement Event Type with ID: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Creates a new Service Requirement Event Type.
        /// </summary>
        /// <param name="serviceRequirementEventTypeDto">The ServiceRequirementEventTypeDTO containing the data for the new Service Requirement Event Type.</param>
        /// <returns>An ActionResult containing the newly created ServiceRequirementEventTypeDTO.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ServiceRequirementEventTypeDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceRequirementEventTypeDTO>> Create([FromBody] ServiceRequirementEventTypeDTO serviceRequirementEventTypeDto)
        {
            if (serviceRequirementEventTypeDto == null)
            {
                _logger.LogError("Service Requirement Event Type DTO is null.");
                return BadRequest("Service Requirement Event Type DTO cannot be null.");
            }

            try
            {
                _logger.LogInformation("Creating a new Service Requirement Event Type.");
                var createdServiceRequirementEventType = await _serviceRequirementEventTypeService.CreateAsync(serviceRequirementEventTypeDto);

                return CreatedAtAction(nameof(GetById), new { id = createdServiceRequirementEventType.Id }, createdServiceRequirementEventType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating a new Service Requirement Event Type.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Updates an existing Service Requirement Event Type.
        /// </summary>
        /// <param name="id">The ID of the Service Requirement Event Type to update.</param>
        /// <param name="serviceRequirementEventTypeDto">The ServiceRequirementEventTypeDTO containing the updated data.</param>
        /// <returns>An IActionResult indicating success or failure.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceRequirementEventTypeDTO serviceRequirementEventTypeDto)
        {
            if (serviceRequirementEventTypeDto == null)
            {
                _logger.LogError("Service Requirement Event Type DTO is null.");
                return BadRequest("Service Requirement Event Type DTO cannot be null.");
            }

            if (id != serviceRequirementEventTypeDto.Id)
            {
                _logger.LogError("ID in the route does not match the ID in the DTO.");
                return BadRequest("ID in the route does not match the ID in the DTO.");
            }

            try
            {
                _logger.LogInformation("Updating Service Requirement Event Type with ID: {Id}", id);
                var existingServiceRequirementEventType = await _serviceRequirementEventTypeService.GetByIdAsync(id);

                if (existingServiceRequirementEventType == null)
                {
                    _logger.LogWarning("Service Requirement Event Type with ID: {Id} not found.", id);
                    return NotFound();
                }

                await _serviceRequirementEventTypeService.UpdateAsync(serviceRequirementEventTypeDto);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Service Requirement Event Type with ID: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Deletes a Service Requirement Event Type by its ID.
        /// </summary>
        /// <param name="id">The ID of the Service Requirement Event Type to delete.</param>
        /// <returns>An IActionResult indicating success or failure.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting Service Requirement Event Type with ID: {Id}", id);
                var existingServiceRequirementEventType = await _serviceRequirementEventTypeService.GetByIdAsync(id);

                if (existingServiceRequirementEventType == null)
                {
                    _logger.LogWarning("Service Requirement Event Type with ID: {Id} not found.", id);
                    return NotFound();
                }

                await _serviceRequirementEventTypeService.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Service Requirement Event Type with ID: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
