using Microsoft.AspNetCore.Mvc;
using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace SynergyApplicationFrameworkApi.Controllers
{
    /// <summary>
    /// Controller for managing Container Instance Automatic Events.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ContainerInstanceAutomaticEventController : ControllerBase
    {
        private readonly ILogger<ContainerInstanceAutomaticEventController> _logger;
        private readonly IContainerInstanceAutomaticEventService _automaticEventService;
        private readonly IPathwayRepository _pathwayRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerInstanceAutomaticEventController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="automaticEventService">The automatic event service.</param>
        /// <param name="pathwayRepository">The pathway repository.</param>
        public ContainerInstanceAutomaticEventController(ILogger<ContainerInstanceAutomaticEventController> logger, IContainerInstanceAutomaticEventService automaticEventService, IPathwayRepository pathwayRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _automaticEventService = automaticEventService ?? throw new ArgumentNullException(nameof(automaticEventService));
            _pathwayRepository = pathwayRepository ?? throw new ArgumentNullException(nameof(pathwayRepository));
        }

        /// <summary>
        /// Creates a new automatic event rule.
        /// </summary>
        /// <param name="request">The create automatic event rule request.</param>
        /// <returns>The ID of the created automatic event rule.</returns>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] CreateAutomaticEventRuleRequest request)
        {
            try
            {
                _logger.LogInformation("Creating a new automatic event rule.");

                if (request == null)
                {
                    _logger.LogError("Create request is null.");
                    return BadRequest("Request cannot be null.");
                }

                int result = _automaticEventService.Create(request, _pathwayRepository);

                _logger.LogInformation("Automatic event rule created successfully with ID: {Result}", result);
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "ArgumentNullException in Create method.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the automatic event rule.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the automatic event rule.");
            }
        }

        /// <summary>
        /// Reads automatic event rules based on the provided request.
        /// </summary>
        /// <param name="request">The read automatic event rule request.</param>
        /// <returns>A list of automatic event details.</returns>
        [HttpPost]
        [Route("Read")]
        [ProducesResponseType(typeof(List<AutomaticEventDetailsDataContract>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Read([FromBody] ReadAutomaticEventRuleRequest request)
        {
            try
            {
                _logger.LogInformation("Reading automatic event rules.");

                if (request == null)
                {
                    _logger.LogError("Read request is null.");
                    return BadRequest("Request cannot be null.");
                }

                List<AutomaticEventDetailsDataContract> data = _automaticEventService.Read(request, _pathwayRepository);

                _logger.LogInformation("Automatic event rules read successfully. Count: {Count}", data.Count);
                return Ok(data);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "ArgumentNullException in Read method.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while reading automatic event rules.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while reading automatic event rules.");
            }
        }

        /// <summary>
        /// Updates a list of automatic event rules.
        /// </summary>
        /// <param name="requestList">The list of update automatic event rule requests.</param>
        /// <returns>The number of updated records.</returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update([FromBody] List<UpdateAutomaticEventRuleRequest> requestList)
        {
            try
            {
                _logger.LogInformation("Updating automatic event rules.");

                if (requestList == null || requestList.Count == 0)
                {
                    _logger.LogError("Update request list is null or empty.");
                    return BadRequest("Request list cannot be null or empty.");
                }

                int result = _automaticEventService.Update(requestList, _pathwayRepository);

                _logger.LogInformation("Automatic event rules updated successfully. Updated count: {Result}", result);
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "ArgumentNullException in Update method.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating automatic event rules.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating automatic event rules.");
            }
        }
    }
}
