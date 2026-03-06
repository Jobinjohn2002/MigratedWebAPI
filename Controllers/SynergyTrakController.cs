using Microsoft.AspNetCore.Mvc;
using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Infrastructure.Repositories;

namespace SynergyApplicationFrameworkApi.Controllers
{
    /// <summary>
    /// Controller for SynergyTrak operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SynergyTrakController : ControllerBase
    {
        private readonly ISynergyTrakService _synergyTrakService;
        private readonly ILogger<SynergyTrakController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SynergyTrakController"/> class.
        /// </summary>
        /// <param name="synergyTrakService">The SynergyTrak service.</param>
        /// <param name="logger">The logger.</param>
        public SynergyTrakController(ISynergyTrakService synergyTrakService, ILogger<SynergyTrakController> logger)
        {
            _synergyTrakService = synergyTrakService ?? throw new ArgumentNullException(nameof(synergyTrakService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Retrospectively adds an asset to a wash batch.
        /// </summary>
        /// <param name="requestDataContract">The data contract containing the details for adding to the wash batch.</param>
        /// <returns>A <see cref="ScanAssetDataContract"/> representing the result of the operation.</returns>
        [HttpPost("RetrospectiveAddToWashBatch")]
        [ProducesResponseType(typeof(ScanAssetDataContract), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ScanAssetDataContract>> RetrospectiveAddToWashBatch([FromBody] AddToWashBatchDataContract requestDataContract)
        {
            if (requestDataContract == null)
            {
                _logger.LogError("RetrospectiveAddToWashBatch: Request data contract is null.");
                return BadRequest("Request data contract cannot be null.");
            }

            try
            {
                var result = await _synergyTrakService.RetrospectiveAddToWashBatch(requestDataContract);

                if (result == null)
                {
                    _logger.LogWarning("RetrospectiveAddToWashBatch: Service returned null result.");
                    return NotFound(); // Or another appropriate status code
                }

                if (result.ErrorCode.HasValue)
                {
                    _logger.LogError($"RetrospectiveAddToWashBatch: Service returned error code: {result.ErrorCode}, Message: {result.Message}");
                    return BadRequest(result); // Or another appropriate status code based on the error code
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RetrospectiveAddToWashBatch: An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }
    }
}
