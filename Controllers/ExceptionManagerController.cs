using Microsoft.AspNetCore.Mvc;
using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
//using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System.ServiceModel;
//using Synergy.Core.Constants;
//using Synergy.ErrorHandling.Exceptions;
//using Synergy.Core;

namespace SynergyApplicationFrameworkApi.Controllers
{
    /// <summary>
    /// Controller for handling exceptions.  Mirrors functionality of the original ServiceExceptionManager.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExceptionManagerController : ControllerBase
    {
        private readonly ILogger<ExceptionManagerController> _logger;
        private readonly ISynergyExceptionHandler _exceptionHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionManagerController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ExceptionManagerController(ILogger<ExceptionManagerController> logger)
        {
            _logger = logger;
            _exceptionHandler = GlobalHandler.Instance;
        }

        /// <summary>
        /// Manages the provided exception.  This endpoint mimics the ManageException methods of the original WCF service.
        /// </summary>
        /// <param name="exceptionDto">A DTO containing the exception to be managed.</param>
        /// <returns>An IActionResult representing the result of the operation.  Returns 500 Internal Server Error with a BasicFaultContract on failure.</returns>
        [HttpPost("ManageException")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ManageException([FromBody] ExceptionDto exceptionDto)
        {
            if (exceptionDto == null || exceptionDto.Exception == null)
            {
                _logger.LogError("ManageException called with null exception.");
                return BadRequest("Exception cannot be null.");
            }

            try
            {
                ProcessException(exceptionDto.Exception);
                return Ok(); // Or NoContent, depending on desired behavior when successful.  Original WCF service throws an exception, so this is never reached in the same way.
            }
            catch (SynergyException ex)
            {
                _logger.LogError(ex, "SynergyException caught in ManageException.");
                var faultContract = new BasicFaultContract(ex.ExceptionId, ex.ErrorMessage);
                return StatusCode(StatusCodes.Status500InternalServerError, faultContract);
            }
            //catch (PathwayException ex)
            //{
            //    _logger.LogError(ex, "PathwayException caught in ManageException.");
            //    var faultContract = new BasicFaultContract(ex.ExceptionId, ex.ErrorMessage);
            //    return StatusCode(StatusCodes.Status500InternalServerError, faultContract);
            //}
            catch (FaultException<BasicFaultContract> ex)
            {
                _logger.LogError(ex, "FaultException caught in ManageException.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Detail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception caught in ManageException.");
                _exceptionHandler.HandleException(ex);
                var faultContract = new BasicFaultContract(string.Empty, "Unknown error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, faultContract);
            }
        }

        /// <summary>
        /// Processes the exception and converts it to a FaultException if necessary.
        /// </summary>
        /// <param name="exception">The exception to process.</param>
        private void ProcessException(Exception exception)
        {
            if (exception is PathwayException pathwayException)
            {
                var faultContract = new BasicFaultContract(pathwayException.ExceptionId, pathwayException.ErrorMessage);
                _logger.LogError(pathwayException, "PathwayException processed.");
                throw new FaultException<BasicFaultContract>(faultContract, new System.ServiceModel.FaultReason(pathwayException.ErrorMessage));
            }
            else if (exception is SynergyException synergyException)
            {
                var faultContract = new BasicFaultContract(synergyException.ExceptionId, synergyException.ErrorMessage);
                _logger.LogError(synergyException, "SynergyException processed.");
                throw new FaultException<BasicFaultContract>(faultContract, new System.ServiceModel.FaultReason(string.Empty));
            }
            else
            {
                _exceptionHandler.HandleException(exception);
                _logger.LogError(exception, "Unhandled exception processed.");
                var faultContract = new BasicFaultContract(string.Empty, "Unknown error occurred.");
                throw new FaultException<BasicFaultContract>(faultContract, new System.ServiceModel.FaultReason("Unknown error occurred."));
            }
        }
    }
}
