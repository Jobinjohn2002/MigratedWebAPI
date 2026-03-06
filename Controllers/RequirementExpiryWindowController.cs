using Microsoft.AspNetCore.Mvc;
using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace SynergyApplicationFrameworkApi.Controllers
{
    /// <summary>
    /// Controller for managing Service Requirement Expiry Windows.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequirementExpiryWindowController : ControllerBase
    {
        private readonly ILogger<ServiceRequirementExpiryWindowController> _logger;
        private readonly IServiceRequirementExpiryWindowService _serviceRequirementExpiryWindowService; // Assuming you have a service

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequirementExpiryWindowController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceRequirementExpiryWindowService">The service for managing Service Requirement Expiry Windows.</param>
        public ServiceRequirementExpiryWindowController(ILogger<ServiceRequirementExpiryWindowController> logger, IServiceRequirementExpiryWindowService serviceRequirementExpiryWindowService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceRequirementExpiryWindowService = serviceRequirementExpiryWindowService ?? throw new ArgumentNullException(nameof(serviceRequirementExpiryWindowService));
        }

        /// <summary>
        /// Retrieves all Service Requirement Expiry Windows.
        /// </summary>
        /// <returns>An ActionResult containing a collection of ServiceRequirementExpiryWindowDTOs.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ServiceRequirementExpiryWindowDTO>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all Service Requirement Expiry Windows.");
                var expiryWindows = await _serviceRequirementExpiryWindowService.GetAllAsync();
                return Ok(expiryWindows);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving Service Requirement Expiry Windows.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Retrieves a Service Requirement Expiry Window by its ID.
        /// </summary>
        /// <param name="id">The ID of the Service Requirement Expiry Window to retrieve.</param>
        /// <returns>An ActionResult containing the ServiceRequirementExpiryWindowDTO, or NotFound if not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceRequirementExpiryWindowDTO>> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Getting Service Requirement Expiry Window with ID: {Id}", id);
                var expiryWindow = await _serviceRequirementExpiryWindowService.GetByIdAsync(id);

                if (expiryWindow == null)
                {
                    _logger.LogWarning("Service Requirement Expiry Window with ID: {Id} not found.", id);
                    return NotFound();
                }

                return Ok(expiryWindow);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving Service Requirement Expiry Window with ID: {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Creates a new Service Requirement Expiry Window.
        /// </summary>
        /// <param name="expiryWindowDto">The ServiceRequirementExpiryWindowDTO containing the data for the new Service Requirement Expiry Window.</param>
        /// <returns>An ActionResult containing the created ServiceRequirementExpiryWindowDTO, or BadRequest if the model is invalid.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceRequirementExpiryWindowDTO>> Create([FromBody] ServiceRequirementExpiryWindowDTO expiryWindowDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Service Requirement Expiry Window.");
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Creating a new Service Requirement Expiry Window.");
                var createdExpiryWindow = await _serviceRequirementExpiryWindowService.CreateAsync(expiryWindowDto);

                return CreatedAtAction(nameof(GetById), new { id = createdExpiryWindow.Id }, createdExpiryWindow);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new Service Requirement Expiry Window.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Updates an existing Service Requirement Expiry Window.
        /// </summary>
        /// <param name="id">The ID of the Service Requirement Expiry Window to update.</param>
        /// <param name="expiryWindowDto">The ServiceRequirementExpiryWindowDTO containing the updated data.</param>
        /// <returns>An ActionResult indicating success (NoContent) or NotFound if the Service Requirement Expiry Window does not exist, or BadRequest if the model is invalid.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceRequirementExpiryWindowDTO expiryWindowDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for updating Service Requirement Expiry Window with ID: {Id}.", id);
                return BadRequest(ModelState);
            }

            if (id != expiryWindowDto.Id)
            {
                _logger.LogWarning("ID mismatch: ID in route ({RouteId}) does not match ID in body ({BodyId}).", id, expiryWindowDto.Id);
                return BadRequest("ID in route does not match ID in body.");
            }

            try
            {
                _logger.LogInformation("Updating Service Requirement Expiry Window with ID: {Id}.", id);
                var existingExpiryWindow = await _serviceRequirementExpiryWindowService.GetByIdAsync(id);
                if (existingExpiryWindow == null)
                {
                    _logger.LogWarning("Service Requirement Expiry Window with ID: {Id} not found for update.", id);
                    return NotFound();
                }

                await _serviceRequirementExpiryWindowService.UpdateAsync(expiryWindowDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating Service Requirement Expiry Window with ID: {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Deletes a Service Requirement Expiry Window by its ID.
        /// </summary>
        /// <param name="id">The ID of the Service Requirement Expiry Window to delete.</param>
        /// <returns>An ActionResult indicating success (NoContent) or NotFound if the Service Requirement Expiry Window does not exist.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting Service Requirement Expiry Window with ID: {Id}.", id);
                var existingExpiryWindow = await _serviceRequirementExpiryWindowService.GetByIdAsync(id);
                if (existingExpiryWindow == null)
                {
                    _logger.LogWarning("Service Requirement Expiry Window with ID: {Id} not found for deletion.", id);
                    return NotFound();
                }

                await _serviceRequirementExpiryWindowService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting Service Requirement Expiry Window with ID: {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
