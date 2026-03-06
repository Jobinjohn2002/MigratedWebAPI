using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ITurnaroundService
    /// </summary>
    public interface ITurnaroundService
    {
        /// <summary>
        /// Reads the number of turnarounds by event type and base type
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <returns></returns>
        IList<TurnaroundData> ReadProductionOverviewByBaseItemType(int facilityId, string customerDefinitions, UserCultureData userCultureData);

        /// <summary>
        /// Reads the number of turnarounds by event type and service requirement
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <returns></returns>
        IList<TurnaroundData> ReadProductionOverviewByServiceRequirement(int facilityId, int? customerDefinitionId);
        IList<TurnaroundData> ReadProductionOverviewByEventType(short facilityId, short? alternateFacilityId);
        IList<TurnaroundData> ReadProductionOverviewByCustomer(short facilityId, short? alternateFacilityId, int productionEventTypeId, Synergy.Core.Data.DataFilter filter, int userId, string userTimeZone, UserCultureData userCultureData, bool useMFP, bool IncludeAlternateFacilityItems);

        /// <summary>
        /// Reads all turnarounds pertaining to the given facility, customer, last process event type, base item type and service requirement
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="alternateFacilityId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <param name="lastProcessEventTypeId"></param>
        /// <param name="baseItemTypeId"></param>
        /// <param name="serviceRequirementId"></param>
        /// <param name="productionEventTypeId"></param>
        /// <param name="filter"></param>
        /// <param name="overDue"></param>
        /// <returns></returns>
        ProductionDataContract ReadTurnaroundsByFacilityAndCustomer(int facilityId, short? alternateFacilityId, string customerDefinitionId, int? productionEventTypeId, int? lastProcessEventTypeId, int? baseItemTypeId, int? serviceRequirementId, Synergy.Core.Data.DataFilter filter, bool? overDue, int userId, string userTimeZone, UserCultureData userCultureData, bool useMFP, bool useEventContext, bool IncludeAlternateFacilityItems);

        /// <summary>
        /// Method to remove turnaround from invoice
        /// </summary>
        /// <param name="turnaroundId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        OperationResponseContract RemoveTurnaroundFromInvoice(int turnaroundId, int userId, int stationId, byte processStationType);

        /// <summary>
        /// this method retuns all visible quarantine reasons.
        /// </summary>
        /// <returns></returns>
        List<KeyValuePair<int, string>> ReadVisibleQuarantineReasonsList(int facilityId, UserCultureData userCultureData);

        /// <summary>
        /// Prints the  service report Audit History.
        /// </summary>
        /// <param name="defectId">The defect id.</param>
        /// <param name="userId">The user Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract PrintServiceReport(int defectId, int userId, UserCultureData userCultureData, bool localPrintingEnabled = false);

        /// <summary>
        /// Prints the  service report Details.
        /// </summary>
        /// <param name="defectId">The defect id.</param>
        /// <param name="userId">The user Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract PrintServiceReportDetails(int defectId, int userId, UserCultureData userCultureData, bool localPrintingEnabled = false);

        /// <summary>
        /// Read Turnarounds For Graph By Facility And Customer
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <param name="lastProcessEventType"></param>
        /// <param name="filter"></param>
        /// <param name="baseItemTypeId"></param>
        /// <returns></returns>
        List<TurnaroundData> ReadTurnaroundsForGraphByFacilityAndCustomer(int facilityId, short? alternateFacilityId, string customerDefinitionId, string lastProcessEventType, int? serviceRequirementDefinitionId, Synergy.Core.Data.DataFilter filter, int? baseItemTypeId, int userId, string userTimeZone, int? productionEventTypeId, UserCultureData userCultureData, bool useMfp, bool IncludeAlternateFacilityItems);
        List<TrackingData> GetTurnaroundBOM(int TurnaroundId);

       /// <summary>
       /// PrintProductionSummary
       /// </summary>
       /// <param name="facilityId"></param>
       /// <param name="userId"></param>
       /// <param name="filter"></param>
       /// <param name="localPrintingEnabled"></param>
       /// <returns></returns>
        OperationResponseContract PrintProductionSummary(short facilityId, int userId, int? baseItemTypeId, int? lastProcessEventTypeId, Synergy.Core.Data.DataFilter filter, string userTimeZone, UserCultureData userCultureData, bool localPrintingEnabled = false);
        Tuple<bool, string> IsTurnaroundOnOrder(int turnaroundId);

        /// <summary>
        /// Return a list of orders that are associated to the turnarounds that are passed in
        /// </summary>
        /// <param name="turnaroundIds"></param>
        /// <returns></returns>
        Tuple<bool, List<string>, List<int>> AreTurnaroundsOnOrders(List<int> turnaroundIds);

        /// <summary>
        /// this method retuns all visible abandon reasons.
        /// </summary>
        /// <returns></returns>
        IList<AbandonReasonData> ReadVisibleAbandonReasons();
        ProductionData ExportProductionData(int facilityId, bool includeStock, UserCultureData culture, List<int> turnaroundIds);
        ProductionData GetProductionDataUnfiltered(int facilityId, bool includeStock, UserCultureData culture);
        List<EventTypeGroupData> GetProductionEventTypeGroups(int facilityId);
        OperationResponseContract PrintProductionData(int facilityId, bool includeStock, UserCultureData culture, List<int> turnaroundIds, int userId, string dateTimeFormat, string timeZone, System.Globalization.CultureInfo currentUICulture);
        byte[] PrintProductionDataLocal(int facilityId, bool includeStock, UserCultureData culture, List<int> turnaroundIds, string dateTimeFormat, string timeZone, System.Globalization.CultureInfo currentUICulture);
        List<int> ValidateArchiveTurnarounds(List<int> turnaroundIds);
        List<int> ValidateNextTurnaroundEvent(List<int> turnaroundIds, TurnAroundEventTypeIdentifier nextEventType);
        OperationResponseContract UpdateTrolleyRestirction(int turnaroundId, bool disabledCustomerTrolleyRestriction,
                                   int userId, int stationId);
        bool IsTurnaroundPreWash(int turnaroundId);
        List<int> ValidateOutOfQuarantine(List<int> turnaroundIds);
    }
}