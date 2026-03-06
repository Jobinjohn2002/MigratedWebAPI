using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ITrakStarService
    /// </summary>
    public interface ITrakStarService
    {
        [WebGet(UriTemplate = "/GetData/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetData(string id);

        /// <summary>
        /// Registers a turnaround event. Used by current operative.
        /// </summary>
        /// <param name="externalId"></param>
        /// <param name="facilityId"></param>
        /// <param name="stationId"></param>
        /// <param name="userId"></param>
        /// <param name="eventTypeId"></param>
        /// <returns></returns>
        ContainerSummaryDatacontract RegisterEvent(string externalId, short facilityId, int stationId, int userId, int eventTypeId);

        /// <summary>
        /// Gets all the facility notes.
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        FacilityNotesDataContract ReadFacilityNotes(int facilityId);

        /// <summary>
        /// Adds a note
        /// </summary>
        /// <param name="turnaroundId"></param>
        /// <param name="noteText"></param>
        /// <param name="userId"></param>
        /// <param name="stationTypes"></param>
        /// <returns></returns>
        BaseReplyDataContract AddNote(int turnaroundId, string noteText, int userId, List<int> stationTypes);

        /// <summary>
        /// Reads the user by external id.
        /// </summary>
        /// <param name="externalId">The external id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        SynergyTrakUserDataContract ReadUserByExternalId(string externalId);

        /// <summary>
        /// Log number of pinAttempts
        /// </summary>
        /// <param name="externalId">The external id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BaseReplyDataContract UpdateUserPinAttempts(int userId, int pinAttempts);

        /// <summary>
        /// Change user PIN
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        BaseReplyDataContract ChangeUserPin(int userId, string pin);
        StaticDataDataContract GetStaticData(short facilityId);
        SearchResultDataContract[] SearchContainers(string containerMasterName);
        ScanContainerDataContract ScanByContainerExternalId(string externalId, int userId, int facilityId, int stationTypeId, int stationId, bool isWashRelease, int? eventType, int? parentTurnaroundId);
        ScanContainerDataContract ScanByContainerId(int containerId, int userId, int facilityId, int stationTypeId, int stationId, bool isWashRelease, int? eventType);
        ScanContainerDataContract ScanByTurnaroundExternalId(long externalId, int userId, int facilityId, int stationTypeId, int stationId, bool isWashRelease, int? eventType);
        ScanContainerDataContract ApplyEvent(int turnaroundId, int userId, int facilityId, int stationTypeId, int stationId, int eventType, bool isWashRelease, int? data);
        KeyValuesDataContract ListFailureTypes(int eventType);
        ClientSettingsDataContract GetClientSettings(string clientName, int? userId);
        ClientSettingsDataContract SaveClientSettings(ClientSettingsDataContract dataContract);
        PriorityItemsDataContract ListPriorityItems(int stationTypeId, short facilityId, int stationId, bool useTurnaroundId);
        ServiceRequirementsDataContract ReadServiceRequirementsByItemTypeAndSrDefinition(int serviceRequirementDefintion, int itemTypeId);
        byte[] CreatePdfReport(string reportName, Tuple<string, string>[] parameters);

    }
}
