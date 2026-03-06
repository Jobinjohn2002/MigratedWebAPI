using Microsoft.AspNetCore.Mvc;
using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace SynergyApplicationFrameworkApi.Controllers
{
    /// <summary>
    /// Controller for handling Service Requirement Expiry operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequirementExpiryController : ControllerBase
    {
        private readonly ILogger<ServiceRequirementExpiryController> _logger;
        private readonly IServiceRequirementExpiryService _serviceRequirementExpiryService; // Assuming you have a service for this

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequirementExpiryController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceRequirementExpiryService">The service for handling Service Requirement Expiry operations.</param>
        public ServiceRequirementExpiryController(ILogger<ServiceRequirementExpiryController> logger, IServiceRequirementExpiryService serviceRequirementExpiryService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceRequirementExpiryService = serviceRequirementExpiryService ?? throw new ArgumentNullException(nameof(serviceRequirementExpiryService));
        }

        /// <summary>
        /// Retrieves the expiry date.
        /// </summary>
        /// <returns>An ActionResult containing the expiry date.</returns>
        [HttpGet("Expiry")]
        public ActionResult<DateTime> GetExpiry()
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve expiry date.");

                // Assuming the service has a method to get the expiry date.  Adjust as needed.
                DateTime expiryDate = _serviceRequirementExpiryService.GetExpiry();

                _logger.LogInformation("Expiry date retrieved successfully.");
                return Ok(expiryDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving expiry date.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates the expiry date.
        /// </summary>
        /// <param name="newExpiry">The new expiry date.</param>
        /// <returns>An ActionResult indicating the result of the update operation.</returns>
        [HttpPut("Expiry")]
        public ActionResult UpdateExpiry(DateTime newExpiry)
        {
            try
            {
                _logger.LogInformation("Attempting to update expiry date.");

                // Assuming the service has a method to update the expiry date.  Adjust as needed.
                _serviceRequirementExpiryService.UpdateExpiry(newExpiry);

                _logger.LogInformation("Expiry date updated successfully.");
                return NoContent(); // Returns 204 No Content on successful update.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating expiry date.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates a new expiry entry.
        /// </summary>
        /// <param name="expiryDate">The expiry date to create.</param>
        /// <returns>An ActionResult indicating the result of the creation operation.</returns>
        [HttpPost("Expiry")]
        public ActionResult CreateExpiry(DateTime expiryDate)
        {
            try
            {
                _logger.LogInformation("Attempting to create a new expiry entry.");

                // Assuming the service has a method to create a new expiry entry.  Adjust as needed.
                _serviceRequirementExpiryService.CreateExpiry(expiryDate);

                _logger.LogInformation("Expiry entry created successfully.");
                return CreatedAtAction(nameof(GetExpiry), new { }, expiryDate); // Returns 201 Created with the location of the new resource.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating expiry entry.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes the expiry entry.
        /// </summary>
        /// <returns>An ActionResult indicating the result of the deletion operation.</returns>
        [HttpDelete("Expiry")]
        public ActionResult DeleteExpiry()
        {
            try
            {
                _logger.LogInformation("Attempting to delete the expiry entry.");

                // Assuming the service has a method to delete the expiry entry.  Adjust as needed.
                _serviceRequirementExpiryService.DeleteExpiry();

                _logger.LogInformation("Expiry entry deleted successfully.");
                return NoContent(); // Returns 204 No Content on successful deletion.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting expiry entry.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
