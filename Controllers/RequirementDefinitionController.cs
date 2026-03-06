using Microsoft.AspNetCore.Mvc;
using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace SynergyApplicationFrameworkApi.Controllers
{
    /// <summary>
    /// Controller for managing Service Requirement Definitions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequirementDefinitionController : ControllerBase
    {
        private readonly ILogger<ServiceRequirementDefinitionController> _logger;
        private readonly IServiceRequirementDefinitionService _serviceRequirementDefinitionService; // Assuming you have a service

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequirementDefinitionController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceRequirementDefinitionService">The service for managing service requirement definitions.</param>
        public ServiceRequirementDefinitionController(ILogger<ServiceRequirementDefinitionController> logger, IServiceRequirementDefinitionService serviceRequirementDefinitionService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceRequirementDefinitionService = serviceRequirementDefinitionService ?? throw new ArgumentNullException(nameof(serviceRequirementDefinitionService));
        }

        /// <summary>
        /// Retrieves all Service Requirement Definitions.
        /// </summary>
        /// <returns>An ActionResult containing a collection of ServiceRequirementDefinitionDTOs.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ServiceRequirementDefinitionDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ServiceRequirementDefinitionDTO>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all Service Requirement Definitions.");
                var serviceRequirementDefinitions = await _serviceRequirementDefinitionService.GetAllAsync();
                return Ok(serviceRequirementDefinitions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all Service Requirement Definitions.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Retrieves a Service Requirement Definition by its ID.
        /// </summary>
        /// <param name="id">The ID of the Service Requirement Definition to retrieve.</param>
        /// <returns>An ActionResult containing the ServiceRequirementDefinitionDTO, or NotFound if not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServiceRequirementDefinitionDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceRequirementDefinitionDTO>> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Getting Service Requirement Definition with ID: {Id}", id);
                var serviceRequirementDefinition = await _serviceRequirementDefinitionService.GetByIdAsync(id);

                if (serviceRequirementDefinition == null)
                {
                    _logger.LogWarning("Service Requirement Definition with ID: {Id} not found.", id);
                    return NotFound();
                }

                return Ok(serviceRequirementDefinition);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Service Requirement Definition with ID: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Creates a new Service Requirement Definition.
        /// </summary>
        /// <param name="serviceRequirementDefinitionDto">The ServiceRequirementDefinitionDTO containing the data for the new Service Requirement Definition.</param>
        /// <returns>An ActionResult containing the created ServiceRequirementDefinitionDTO, or BadRequest if the model is invalid.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ServiceRequirementDefinitionDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceRequirementDefinitionDTO>> Create([FromBody] ServiceRequirementDefinitionDTO serviceRequirementDefinitionDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Service Requirement Definition.");
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Creating a new Service Requirement Definition.");
                var createdServiceRequirementDefinition = await _serviceRequirementDefinitionService.CreateAsync(serviceRequirementDefinitionDto);

                return CreatedAtAction(nameof(GetById), new { id = createdServiceRequirementDefinition.Id }, createdServiceRequirementDefinition);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating a new Service Requirement Definition.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Updates an existing Service Requirement Definition.
        /// </summary>
        /// <param name="id">The ID of the Service Requirement Definition to update.</param>
        /// <param name="serviceRequirementDefinitionDto">The ServiceRequirementDefinitionDTO containing the updated data.</param>
        /// <returns>An ActionResult indicating success (NoContent) or NotFound if the Service Requirement Definition does not exist, or BadRequest if the model is invalid.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceRequirementDefinitionDTO serviceRequirementDefinitionDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for updating Service Requirement Definition with ID: {Id}", id);
                return BadRequest(ModelState);
            }

            if (id != serviceRequirementDefinitionDto.Id)
            {
                _logger.LogWarning("ID mismatch for updating Service Requirement Definition.  ID in route: {RouteId}, ID in body: {BodyId}", id, serviceRequirementDefinitionDto.Id);
                return BadRequest("ID in route does not match ID in body.");
            }

            try
            {
                _logger.LogInformation("Updating Service Requirement Definition with ID: {Id}", id);
                var existingServiceRequirementDefinition = await _serviceRequirementDefinitionService.GetByIdAsync(id);

                if (existingServiceRequirementDefinition == null)
                {
                    _logger.LogWarning("Service Requirement Definition with ID: {Id} not found for update.", id);
                    return NotFound();
                }

                await _serviceRequirementDefinitionService.UpdateAsync(serviceRequirementDefinitionDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Service Requirement Definition with ID: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Deletes a Service Requirement Definition by its ID.
        /// </summary>
        /// <param name="id">The ID of the Service Requirement Definition to delete.</param>
        /// <returns>An ActionResult indicating success (NoContent) or NotFound if the Service Requirement Definition does not exist.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting Service Requirement Definition with ID: {Id}", id);
                var existingServiceRequirementDefinition = await _serviceRequirementDefinitionService.GetByIdAsync(id);

                if (existingServiceRequirementDefinition == null)
                {
                    _logger.LogWarning("Service Requirement Definition with ID: {Id} not found for deletion.", id);
                    return NotFound();
                }

                await _serviceRequirementDefinitionService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Service Requirement Definition with ID: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
