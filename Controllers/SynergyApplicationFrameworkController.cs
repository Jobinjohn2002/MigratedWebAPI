using Microsoft.AspNetCore.Mvc;
using SynergyApplicationFrameworkApi.Application.Services;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
//using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Controllers;

/// <summary>
/// SynergyApplicationFramework API Controller
/// Provides REST endpoints for SynergyApplicationFramework operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SynergyApplicationFrameworkController : ControllerBase
{
    private readonly ILogger<SynergyApplicationFrameworkController> _logger;
    
    /// <summary>
    /// Initializes a new instance of SynergyApplicationFrameworkController
    /// </summary>
    public SynergyApplicationFrameworkController(ILogger<SynergyApplicationFrameworkController> logger)
    {
        _logger = logger;
    }

/// <summary>
/// Loads a specific instance onto a trolley for a given turnaround, user, and station.
/// </summary>
/// <param name="instanceId">The unique identifier of the instance to load.</param>
/// <param name="trolleyTurnaroundId">The unique identifier of the trolley turnaround event.</param>
/// <param name="userId">The unique identifier of the user performing the action.</param>
/// <param name="stationId">The unique identifier of the station where the loading is occurring.</param>
/// <returns>Returns true if the instance was successfully loaded onto the trolley; otherwise, false.  Returns an error if an exception occurs.</returns>
[HttpPost("loadinstanceontotrolley")]
public async Task<ActionResult<bool>> LoadInstanceOntoTrolley(int instanceId, int trolleyTurnaroundId, int userId, int stationId)
{
    try
    {
        _logger.LogInformation("Executing LoadInstanceOntoTrolley with instanceId: {InstanceId}, trolleyTurnaroundId: {TrolleyTurnaroundId}, userId: {UserId}, stationId: {StationId}", instanceId, trolleyTurnaroundId, userId, stationId);

        // Simulate successful loading (replace with actual business logic)
        // In a real implementation, you would interact with a database or other data source here.
        // Example:
        // bool success = await _trolleyService.LoadInstance(instanceId, trolleyTurnaroundId, userId, stationId);
        // if (!success)
        // {
        //     return BadRequest("Failed to load instance onto trolley.");
        // }

        // For now, simulate success:
        bool success = true;

        if (success)
        {
            return Ok(true);
        }
        else
        {
            return BadRequest(false); // Or a more specific error code
        }
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in LoadInstanceOntoTrolley with instanceId: {InstanceId}, trolleyTurnaroundId: {TrolleyTurnaroundId}, userId: {UserId}, stationId: {StationId}", instanceId, trolleyTurnaroundId, userId, stationId);
        return StatusCode(500, new { error = "An error occurred while loading the instance onto the trolley." });
    }
}



        /// <summary>
        /// Attempts to retrospectively add a container instance to an existing wash batch.  This is typically used when a container was processed without being properly associated with a batch initially.
        /// </summary>
        /// <param name="fromContainerInstance">The ID of the container instance to be added to the wash batch.</param>
        /// <param name="toContainerInstance">The ID of the container instance representing the wash batch to add to.</param>
        /// <param name="stationId">The ID of the wash station where the wash batch was processed.</param>
        /// <param name="userId">The ID of the user performing the action.</param>
        /// <returns>True if the container instance was successfully added to the wash batch; otherwise, false.  Returns an error if any exception occurs.</returns>
        [HttpPost("retrospectiveaddtowashbatch")]
        public async Task<ActionResult<bool>> RetrospectiveAddToWashBatch(int fromContainerInstance, int toContainerInstance, int stationId,  int userId)
        {
            try
            {
                _logger.LogInformation("Executing RetrospectiveAddToWashBatch with fromContainerInstance: {FromContainerInstance}, toContainerInstance: {ToContainerInstance}, stationId: {StationId}, userId: {UserId}", fromContainerInstance, toContainerInstance, stationId, userId);

                // TODO: Implement business logic to add the container instance to the wash batch.
                // This would likely involve:
                // 1. Validating the input parameters (e.g., checking if the container instances exist, if the station ID is valid).
                // 2. Checking if the 'toContainerInstance' is a valid wash batch container.
                // 3. Updating the database to associate the 'fromContainerInstance' with the 'toContainerInstance' wash batch.
                // 4. Potentially updating other related tables or entities.

                // Placeholder return value - replace with actual result from business logic.
                // For example:
                // bool success = await _washBatchService.AddToWashBatchAsync(fromContainerInstance, toContainerInstance, stationId, userId);
                // return Ok(success);

                throw new NotImplementedException("Business logic pending");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in RetrospectiveAddToWashBatch with fromContainerInstance: {FromContainerInstance}, toContainerInstance: {ToContainerInstance}, stationId: {StationId}, userId: {UserId}", fromContainerInstance, toContainerInstance, stationId, userId);
                return StatusCode(500, new { error = ex.Message });
            }
        }



/// <summary>
/// Marks a delivery note as delivered at a specific station by a specific user.
/// </summary>
/// <param name="deliveryNoteId">The unique identifier of the delivery note.</param>
/// <param name="stationId">The unique identifier of the station where the delivery is being made.</param>
/// <param name="userId">The unique identifier of the user performing the delivery.</param>
/// <returns>True if the delivery note was successfully marked as delivered; otherwise, false.</returns>
[HttpPost("deliverdeliverynote")]
public async Task<ActionResult<bool>> DeliverDeliveryNote(int deliveryNoteId, int stationId, int userId)
{
    try
    {
        _logger.LogInformation("Executing DeliverDeliveryNote with deliveryNoteId: {DeliveryNoteId}, stationId: {StationId}, userId: {UserId}", deliveryNoteId, stationId, userId);

        // TODO: Implement business logic to mark the delivery note as delivered.
        // This would typically involve:
        // 1. Validating the deliveryNoteId, stationId, and userId.
        // 2. Checking if the delivery note is in a valid state for delivery.
        // 3. Updating the delivery note status in the database.
        // 4. Potentially triggering other events or notifications.

        // Placeholder for successful delivery.  Replace with actual logic.
        // For example:
        // bool success = await _deliveryNoteService.MarkAsDeliveredAsync(deliveryNoteId, stationId, userId);
        // if (success) { return Ok(true); } else { return BadRequest("Failed to mark delivery note as delivered."); }

        throw new NotImplementedException("Business logic pending");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in DeliverDeliveryNote with deliveryNoteId: {DeliveryNoteId}, stationId: {StationId}, userId: {UserId}", deliveryNoteId, stationId, userId);
        return StatusCode(500, new { error = "An error occurred while processing the delivery note." });
    }
}



/// <summary>
/// Adds a turnaround to a specific storage point.
/// </summary>
/// <param name="storagePointId">The unique identifier of the storage point.</param>
/// <param name="turnaroundExternalId">The external identifier of the turnaround.</param>
/// <param name="stationId">The unique identifier of the station associated with the turnaround.</param>
/// <param name="userId">The unique identifier of the user performing the action.</param>
/// <returns>True if the turnaround was successfully added to the storage point; otherwise, false.</returns>
[HttpPost("AddTurnaroundToStoragePoint")]
public async Task<ActionResult<bool>> AddTurnaroundToStoragePoint(int storagePointId, long turnaroundExternalId, int stationId, int userId)
{
    try
    {
        _logger.LogInformation("Executing AddTurnaroundToStoragePoint with storagePointId: {StoragePointId}, turnaroundExternalId: {TurnaroundExternalId}, stationId: {StationId}, userId: {UserId}", storagePointId, turnaroundExternalId, stationId, userId);

        // TODO: Implement business logic to add the turnaround to the storage point.
        // Example:
        // bool success = await _storagePointService.AddTurnaround(storagePointId, turnaroundExternalId, stationId, userId);

        // For now, simulate success.  Replace with actual logic.
        bool success = true;

        if (success)
        {
            _logger.LogInformation("Turnaround {TurnaroundExternalId} successfully added to storage point {StoragePointId}.", turnaroundExternalId, storagePointId);
            return Ok(true);
        }
        else
        {
            _logger.LogWarning("Failed to add turnaround {TurnaroundExternalId} to storage point {StoragePointId}.", turnaroundExternalId, storagePointId);
            return BadRequest(false); // Or another appropriate status code.
        }
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in AddTurnaroundToStoragePoint with storagePointId: {StoragePointId}, turnaroundExternalId: {TurnaroundExternalId}, stationId: {StationId}, userId: {UserId}", storagePointId, turnaroundExternalId, stationId, userId);
        return StatusCode(500, new { error = "An error occurred while adding the turnaround to the storage point." });
    }
}



/// <summary>
/// Adds a trolley to a specific storage point within a station, recording the user who performed the action.
/// </summary>
/// <param name="storagePointId">The unique identifier of the storage point.</param>
/// <param name="trolleyId">The unique identifier of the trolley to be added.</param>
/// <param name="stationId">The unique identifier of the station where the storage point is located.</param>
/// <param name="userId">The unique identifier of the user performing the action.</param>
/// <returns>True if the trolley was successfully added to the storage point; otherwise, false.</returns>
[HttpPost("AddTrolleyToStoragePoint")]
public async Task<ActionResult<bool>> AddTrolleyToStoragePoint(int storagePointId, int trolleyId, int stationId, int userId)
{
    try
    {
        _logger.LogInformation($"Attempting to add trolley {trolleyId} to storage point {storagePointId} at station {stationId} by user {userId}.");

        // TODO: Implement business logic to:
        // 1. Validate the existence of the storage point, trolley, and station.
        // 2. Check if the storage point has available capacity.
        // 3. Update the storage point to include the trolley.
        // 4. Record the action in an audit log.

        // Placeholder for successful operation.  Replace with actual logic.
        // For example:
        // bool success = await _storagePointService.AddTrolley(storagePointId, trolleyId, stationId, userId);
        // if (success) {
        //     return Ok(true);
        // } else {
        //     return BadRequest("Failed to add trolley to storage point.");
        // }

        // Simulate success for now.
        bool success = true;

        if (success)
        {
            _logger.LogInformation($"Trolley {trolleyId} successfully added to storage point {storagePointId}.");
            return Ok(true);
        }
        else
        {
            _logger.LogWarning($"Failed to add trolley {trolleyId} to storage point {storagePointId}.");
            return BadRequest("Failed to add trolley to storage point.");
        }
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, $"Error adding trolley {trolleyId} to storage point {storagePointId}: {ex.Message}");
        return StatusCode(500, new { error = "An error occurred while adding the trolley to the storage point." });
    }
}



/// <summary>
/// Retrieves a list of configurable list values for a specific tenancy, optionally filtered by event type.
/// </summary>
/// <param name="listTypeId">The ID of the list type to retrieve values for.</param>
/// <param name="tenancyId">The ID of the tenancy to retrieve values for.</param>
/// <param name="eventTypeId">Optional. The ID of the event type to filter the list values by. If null, all list values for the tenancy are returned.</param>
/// <returns>A ConfigurableListDataContract containing the list of configurable list values. Returns NotFound if no values are found. Returns StatusCode 500 for internal server errors.</returns>
[HttpGet("getcustomisablelistvaluesfortenancy")]
public async Task<ActionResult<ConfigurableListDataContract>> GetCustomisableListValuesForTenancy(int listTypeId, int tenancyId, int? eventTypeId)
{
    try
    {
        _logger.LogInformation("Executing GetCustomisableListValuesForTenancy with listTypeId: {ListTypeId}, tenancyId: {TenancyId}, eventTypeId: {EventTypeId}", listTypeId, tenancyId, eventTypeId);

        // Simulate retrieving data (replace with actual data access logic)
        // For example:
        // var listValues = await _configurableListService.GetListValues(listTypeId, tenancyId, eventTypeId);

        // Simulate no data found
        // if (listValues == null || !listValues.Any())
        // {
        //     _logger.LogWarning("No configurable list values found for listTypeId: {ListTypeId}, tenancyId: {TenancyId}, eventTypeId: {EventTypeId}", listTypeId, tenancyId, eventTypeId);
        //     return NotFound();
        // }

        // Simulate returning data
        // var dataContract = new ConfigurableListDataContract { ListValues = listValues };
        // return Ok(dataContract);

        throw new NotImplementedException("Business logic pending");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in GetCustomisableListValuesForTenancy with listTypeId: {ListTypeId}, tenancyId: {TenancyId}, eventTypeId: {EventTypeId}", listTypeId, tenancyId, eventTypeId);
        return StatusCode(500, new { error = "An error occurred while processing your request." });
    }
}



/// <summary>
/// Retrieves a list of configured defect responsibilities for a specific facility.
/// Each responsibility is represented as a key-value pair, where the key is a byte representing the responsibility ID and the value is a string representing the responsibility description.
/// </summary>
/// <param name="facilityId">The ID of the facility for which to retrieve defect responsibilities.</param>
/// <returns>A list of key-value pairs representing the configured defect responsibilities for the specified facility.  Returns an empty list if no responsibilities are configured or an error occurs.  Returns a 500 Internal Server Error if an unexpected exception occurs.</returns>
[HttpGet("getconfigureddefectresponsibilities")]
public async Task<ActionResult<List<KeyValuePair<byte, string>>>> GetConfiguredDefectResponsibilities(int facilityId)
{
    try
    {
        _logger.LogInformation("Executing GetConfiguredDefectResponsibilities for facilityId: {FacilityId}", facilityId);

        // Simulate retrieving data from a data source (e.g., database).
        // Replace this with your actual data access logic.
        List<KeyValuePair<byte, string>> responsibilities = new List<KeyValuePair<byte, string>>();

        // Example data (replace with actual data retrieval)
        if (facilityId == 1)
        {
            responsibilities.Add(new KeyValuePair<byte, string>(1, "Maintenance Team"));
            responsibilities.Add(new KeyValuePair<byte, string>(2, "Engineering Department"));
        }
        else if (facilityId == 2)
        {
            responsibilities.Add(new KeyValuePair<byte, string>(3, "Quality Assurance"));
        }

        _logger.LogInformation("Successfully retrieved defect responsibilities for facilityId: {FacilityId}. Count: {Count}", facilityId, responsibilities.Count);
        return Ok(responsibilities);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in GetConfiguredDefectResponsibilities for facilityId: {FacilityId}", facilityId);
        return StatusCode(500, new { error = "An unexpected error occurred while retrieving defect responsibilities." });
    }
}



/// <summary>
/// Retrieves all reports associated with a specific user.
/// </summary>
/// <param name="userId">The unique identifier of the user.</param>
/// <returns>A list of ReportData objects representing the reports for the user. Returns an empty list if no reports are found. Returns a 500 Internal Server Error if an exception occurs.</returns>
[HttpGet("getallreportsforuser")]
public async Task<ActionResult<List<ReportData>>> GetAllReportsForUser(int userId)
{
    try
    {
        _logger.LogInformation("Executing GetAllReportsForUser for userId: {UserId}", userId);

        // Simulate retrieving data (replace with actual data access logic)
        // For example:
        // var reports = await _reportService.GetReportsByUserIdAsync(userId);
        // if (reports == null || !reports.Any())
        // {
        //     return Ok(new List<ReportData>()); // Return empty list if no reports found
        // }
        // return Ok(reports);

        // Placeholder for business logic
        throw new NotImplementedException("Business logic pending - Implement data retrieval and mapping to ReportData.");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in GetAllReportsForUser for userId: {UserId}", userId);
        return StatusCode(500, new { error = "An error occurred while processing your request." }); // Generic error message for security
    }
}



/// <summary>
/// Retrieves all favourite reports for a given user.
/// </summary>
/// <param name="userId">The ID of the user whose favourite reports are to be retrieved.</param>
/// <returns>A list of FavouriteReportContract objects representing the user's favourite reports. Returns an empty list if no favourite reports are found. Returns a 500 Internal Server Error if an exception occurs.</returns>
[HttpGet("getallfavouritereports")]
public async Task<ActionResult<List<FavouriteReportContract>>> GetAllFavouriteReports(int userId)
{
    try
    {
        _logger.LogInformation("Executing GetAllFavouriteReports for userId: {UserId}", userId);

        // Simulate retrieving data from a data source (e.g., database)
        // Replace this with your actual data access logic
        // Example:
        // var favouriteReports = await _reportService.GetFavouriteReportsByUserIdAsync(userId);

        // For now, return an empty list as the business logic is pending
        List<FavouriteReportContract> favouriteReports = new List<FavouriteReportContract>();

        _logger.LogInformation("Successfully retrieved {Count} favourite reports for userId: {UserId}", favouriteReports.Count, userId);

        return Ok(favouriteReports);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in GetAllFavouriteReports for userId: {UserId}", userId);
        return StatusCode(500, new { error = "An error occurred while retrieving favourite reports." });
    }
}



/// <summary>
/// Deletes a favourite report based on its ID.
/// </summary>
/// <param name="favouriteReportId">The ID of the favourite report to delete.</param>
/// <returns>An OperationResponseContract indicating the success or failure of the operation.</returns>
[HttpDelete("{favouriteReportId}")]
public async Task<ActionResult<OperationResponseContract>> DeleteFavouriteReport(int favouriteReportId)
{
    try
    {
        _logger.LogInformation("Executing DeleteFavouriteReport with ID: {FavouriteReportId}", favouriteReportId);

        // TODO: Implement business logic to delete the favourite report.
        // Example:
        // var result = await _favouriteReportService.DeleteFavouriteReportAsync(favouriteReportId);

        //if (!result.IsSuccess)
        //{
        //    _logger.LogError("Failed to delete favourite report with ID: {FavouriteReportId}. Error: {ErrorMessage}", favouriteReportId, result.ErrorMessage);
        //    return BadRequest(new OperationResponseContract { IsSuccess = false, ErrorMessage = result.ErrorMessage });
        //}

        //_logger.LogInformation("Successfully deleted favourite report with ID: {FavouriteReportId}", favouriteReportId);
        //return Ok(new OperationResponseContract { IsSuccess = true });

        throw new NotImplementedException("Business logic pending");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in DeleteFavouriteReport with ID: {FavouriteReportId}", favouriteReportId);
        return StatusCode(500, new OperationResponseContract { Successful = false, Message = "An unexpected error occurred." });
    }
}



    /// <summary>
    /// Creates a new favourite report in the system.
    /// </summary>
    /// <param name="favouriteReportContract">The data for the new favourite report.</param>
    /// <returns>The ID of the newly created favourite report. Returns 500 if an error occurs.</returns>
    [HttpPost("createfavouritereport")]
    public async Task<ActionResult<int>> CreateFavouriteReport(FavouriteReportContract favouriteReportContract)
    {
    try
    {
        _logger.LogInformation("Executing CreateFavouriteReport");
        throw new NotImplementedException("Business logic pending");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in CreateFavouriteReport");
        return StatusCode(500, new { error = ex.Message });
    }
}



/// <summary>
/// Edits an existing favourite report.
/// </summary>
/// <param name="favouriteReportContract">The updated favourite report data.</param>
/// <returns>An OperationResponseContract indicating the success or failure of the operation.</returns>
[HttpPut("{id}")]
public async Task<ActionResult<OperationResponseContract>> EditFavouriteReport(FavouriteReportContract favouriteReportContract)
{
    try
    {
        _logger.LogInformation("Executing EditFavouriteReport");
        throw new NotImplementedException("Business logic pending");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in EditFavouriteReport");
        return StatusCode(500, new { error = ex.Message });
    }
}



/// <summary>
/// Retrieves a list of available output types for a given report ID.
/// </summary>
/// <param name="reportId">The ID of the report to retrieve output types for.</param>
/// <returns>A list of ReportOutputTypeContract objects representing the available output types. Returns an error if an exception occurs.</returns>
[HttpGet("getreportoutputtypes")]
public async Task<ActionResult<List<ReportOutputTypeContract>>> GetReportOutputTypes(short reportId)
{
    try
    {
        _logger.LogInformation("Executing GetReportOutputTypes for reportId: {ReportId}", reportId);

        // Simulate retrieving data (replace with actual data access logic)
        // For example:
        // var outputTypes = await _reportService.GetReportOutputTypesAsync(reportId);
        // if (outputTypes == null || !outputTypes.Any())
        // {
        //     return NotFound($"No output types found for report ID: {reportId}");
        // }

        // Placeholder for actual data retrieval and mapping
        List<ReportOutputTypeContract> outputTypes = new List<ReportOutputTypeContract>()
        {
            new ReportOutputTypeContract { Id = 1, Name = "PDF" },
            new ReportOutputTypeContract { Id = 2, Name = "Excel" }
        };

        return Ok(outputTypes);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in GetReportOutputTypes for reportId: {ReportId}", reportId);
        return StatusCode(500, new { error = "An error occurred while processing your request." });
    }
}



/// <summary>
/// Marks a report as a favorite for a specific user.
/// </summary>
/// <param name="userId">The ID of the user.</param>
/// <param name="reportId">The ID of the report to mark as favorite.</param>
/// <returns>An OperationResponseContract containing the number of favorite reports for the user, or an error if the operation fails.</returns>
[HttpPost("markreportasfavourite")]
public async Task<ActionResult<OperationResponseContract<int>>> MarkReportAsFavourite(int userId, short reportId)
{
    try
    {
        _logger.LogInformation("Executing MarkReportAsFavourite for userId: {UserId}, reportId: {ReportId}", userId, reportId);

        // Simulate adding the report to the user's favorites.  Replace with actual business logic.
        // For example, you might call a service to update a database.
        // This example just increments a counter.

        // Placeholder for business logic - replace with your actual implementation
        // Example:
        // var result = await _reportService.MarkAsFavoriteAsync(userId, reportId);
        // if (!result.Success)
        // {
        //     return BadRequest(new OperationResponseContract<int> { Success = false, ErrorMessage = result.ErrorMessage });
        // }

        // Simulate retrieving the number of favorite reports for the user.
        // Replace with your actual data retrieval logic.
        int numberOfFavoriteReports = 5; // Replace with actual count from database or service

        var response = new OperationResponseContract<int>
        {
            Successful = true,
            Data = numberOfFavoriteReports,
            Message = "Report marked as favorite successfully."
        };

        _logger.LogInformation("MarkReportAsFavourite completed successfully for userId: {UserId}, reportId: {ReportId}.  Number of favorites: {NumberOfFavorites}", userId, reportId, numberOfFavoriteReports);
        return Ok(response);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in MarkReportAsFavourite for userId: {UserId}, reportId: {ReportId}", userId, reportId);
        return StatusCode(500, new OperationResponseContract<int> { Successful = false, Message = "An error occurred while marking the report as favorite." });
    }
}



/// <summary>
/// Retrieves a favourite report by its ID.
/// </summary>
/// <param name="favouriteReportId">The unique identifier of the favourite report to retrieve.</param>
/// <returns>An ActionResult containing the FavouriteReportContract if found, otherwise an error.</returns>
[HttpGet("getfavouritereport")]
public async Task<ActionResult<FavouriteReportContract>> GetFavouriteReport(int favouriteReportId)
{
    try
    {
        _logger.LogInformation("Executing GetFavouriteReport with ID: {FavouriteReportId}", favouriteReportId);

        // Simulate retrieving the report from a data source.  Replace with actual data access logic.
        // For example, using Entity Framework:
        // var report = await _context.FavouriteReports.FindAsync(favouriteReportId);

        // Placeholder for business logic - replace with actual implementation
        //if (report == null)
        //{
        //    _logger.LogWarning("Favourite report with ID {FavouriteReportId} not found.", favouriteReportId);
        //    return NotFound();
        //}

        // Map the data entity to the contract.  Replace with AutoMapper or manual mapping.
        //var contract = new FavouriteReportContract
        //{
        //    Id = report.Id,
        //    Name = report.Name,
        //    Description = report.Description
        //};

        // Simulate a successful retrieval and return the contract.
        //return Ok(contract);

        // For now, throw a NotImplementedException to indicate that the business logic is pending.
        throw new NotImplementedException("Business logic pending: Implement data retrieval and mapping to FavouriteReportContract.");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in GetFavouriteReport with ID: {FavouriteReportId}", favouriteReportId);
        return StatusCode(500, new { error = "An error occurred while processing your request." }); // Generic error message for security.  Log the specific error.
    }
}



/// <summary>
/// Retrieves a list of saved parameter collections for a user's favorite report.
/// </summary>
/// <param name="userId">The ID of the user.</param>
/// <param name="reportId">The ID of the report.</param>
/// <returns>A list of UsersSavedReportParameterCollection objects. Returns an empty list if no parameters are found. Returns a 500 Internal Server Error if an exception occurs.</returns>
[HttpGet("getlistofparametersforfavouritereport")]
public async Task<ActionResult<List<UsersSavedReportParameterCollection>>> GetListOfParametersForFavouriteReport(int userId, int reportId)
{
    try
    {
        _logger.LogInformation("Executing GetListOfParametersForFavouriteReport with userId: {UserId} and reportId: {ReportId}", userId, reportId);

        // TODO: Implement business logic to retrieve the saved report parameters.
        // Example:
        // var parameters = await _reportService.GetSavedReportParameters(userId, reportId);
        // return Ok(parameters);

        throw new NotImplementedException("Business logic pending");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in GetListOfParametersForFavouriteReport with userId: {UserId} and reportId: {ReportId}", userId, reportId);
        return StatusCode(500, new { error = ex.Message });
    }
}



/// <summary>
/// Checks if a Container Instance with the given ID is archived in both CM (Content Management) and LKR (Likelihood of Recovery) systems.
/// </summary>
/// <param name="containerInstanceId">The ID of the Container Instance to check.</param>
/// <returns>True if the Container Instance is archived in both CM and LKR, false otherwise.</returns>
[HttpPost("checkarchivecmandlkr")]
public async Task<ActionResult<bool>> CheckArchiveCMAndLKR(int containerInstanceId)
{
    try
    {
        _logger.LogInformation("Executing CheckArchiveCMAndLKR for ContainerInstanceId: {ContainerInstanceId}", containerInstanceId);

        // Simulate checking CM and LKR systems.  Replace with actual business logic.
        bool isArchivedInCM = await Task.FromResult(containerInstanceId % 2 == 0); // Example: Even IDs are archived in CM
        bool isArchivedInLKR = await Task.FromResult(containerInstanceId > 100); // Example: IDs greater than 100 are archived in LKR

        bool isArchived = isArchivedInCM && isArchivedInLKR;

        _logger.LogInformation("ContainerInstanceId: {ContainerInstanceId} - Archived in CM: {IsArchivedInCM}, Archived in LKR: {IsArchivedInLKR}, Overall Archived: {IsArchived}", containerInstanceId, isArchivedInCM, isArchivedInLKR, isArchived);

        return Ok(isArchived);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in CheckArchiveCMAndLKR for ContainerInstanceId: {ContainerInstanceId}", containerInstanceId);
        return StatusCode(500, new { error = ex.Message });
    }
}


    /// <summary>
    /// Creates a linking between a case and other related entities (e.g., documents, parties).  This endpoint handles the creation of these links based on provided data.
    /// </summary>
    /// <returns>An ActionResult indicating success or failure.  Returns 200 OK on success, or an appropriate error code (e.g., 400 Bad Request, 500 Internal Server Error) on failure.</returns>
    [HttpPost("createlinkingforcase")]
    public async Task<ActionResult> CreateLinkingForCase()
    {
    try
    {
        _logger.LogInformation("Executing CreateLinkingForCase");
        // TODO: Implement the business logic for creating the linking.
        // This will likely involve:
        // 1.  Retrieving data from the request body (e.g., case ID, related entity IDs).
        // 2.  Validating the data.
        // 3.  Creating the linking in the database.
        // 4.  Returning a success response.

        // Placeholder for successful execution.  Replace with actual logic.
        return Ok();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in CreateLinkingForCase");
        return StatusCode(500, new { error = ex.Message });
    }
}



/// <summary>
/// Retrieves a list of exception dates for a specific item within a container instance.
/// </summary>
/// <param name="externalId">The external identifier of the item.</param>
/// <param name="containerInstanceId">The identifier of the container instance.</param>
/// <returns>A list of ItemExceptionsDataContract objects representing the exception dates. Returns an empty list if no exceptions are found. Returns a 500 Internal Server Error if an error occurs.</returns>
[HttpGet("getitemexceptiondates")]
public async Task<ActionResult<List<ItemExceptionsDataContract>>> GetItemExceptionDates(string externalId, int containerInstanceId)
{
    try
    {
        _logger.LogInformation("Executing GetItemExceptionDates with externalId: {ExternalId} and containerInstanceId: {ContainerInstanceId}", externalId, containerInstanceId);

        // TODO: Implement business logic to retrieve item exception dates based on externalId and containerInstanceId.
        // Example:
        // var exceptionDates = await _itemExceptionService.GetExceptionDates(externalId, containerInstanceId);
        // return Ok(exceptionDates);

        throw new NotImplementedException("Business logic pending");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in GetItemExceptionDates with externalId: {ExternalId} and containerInstanceId: {ContainerInstanceId}", externalId, containerInstanceId);
        return StatusCode(500, new { error = "An error occurred while processing the request." });
    }
}



/// <summary>
/// Retrieves a list of item exception dates based on the external ID and turnaround ID.
/// </summary>
/// <param name="externalId">The external identifier of the item.</param>
/// <param name="turnaroundId">The identifier of the turnaround.</param>
/// <returns>A list of ItemExceptionsDataContract objects representing the exception dates. Returns an empty list if no exceptions are found. Returns a 500 Internal Server Error if an exception occurs.</returns>
[HttpGet("getitemexceptiondatesbyturnaroundid")]
public async Task<ActionResult<List<ItemExceptionsDataContract>>> GetItemExceptionDatesByTurnaroundId(string externalId, int turnaroundId)
{
    try
    {
        _logger.LogInformation("Executing GetItemExceptionDatesByTurnaroundId with externalId: {ExternalId} and turnaroundId: {TurnaroundId}", externalId, turnaroundId);

        // Simulate retrieving data (replace with actual data access logic)
        // For example:
        // var exceptions = await _itemExceptionService.GetExceptions(externalId, turnaroundId);
        // if (exceptions == null || !exceptions.Any())
        // {
        //     return Ok(new List<ItemExceptionsDataContract>()); // Return empty list if no exceptions found
        // }

        // Map the data to the data contract (replace with actual mapping)
        // var dataContracts = exceptions.Select(e => new ItemExceptionsDataContract { ExceptionDate = e.ExceptionDate }).ToList();

        // For now, return an empty list as a placeholder
        List<ItemExceptionsDataContract> dataContracts = new List<ItemExceptionsDataContract>();

        return Ok(dataContracts);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in GetItemExceptionDatesByTurnaroundId with externalId: {ExternalId} and turnaroundId: {TurnaroundId}", externalId, turnaroundId);
        return StatusCode(500, new { error = "An error occurred while processing the request." });
    }
}


}
