using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IMaintenanceReportService
    /// </summary>
    public interface IMaintenanceReportService
    {
        /// <summary>
        /// To retrieve Archive reasons
        /// </summary>
        IList<MaintenanceReportData> ReadAllMaintenanceReports();

        /// <summary>
        /// To retrieve Maintenance Report by container instance id
        /// </summary>
        IList<MaintenanceReportData> ReadMaintenanceReportByContainerInstance(int containerInstanceId);

        /// <summary>
        /// To retrieve Maintenance Report by Turnaround id
        /// </summary>
        IList<MaintenanceReportData> ReadMaintenanceReportByTurnaroundId(int turnaroundId);

        /// <summary>
        /// Get All Maintenance Types
        /// </summary>
        IList<MaintenanceTypeData> ReadAllMaintenanceTypes(bool isSystemProcess);

        /// <summary>
        /// Gets the maintenance report.
        /// </summary>
        /// <param name="maintenanceReportId">The maintenance report id.</param>
        MaintenanceReportData GetMaintenanceReport(int maintenanceReportId);

        /// <summary>
        /// Gets the maintenance report.
        /// </summary>
        /// <param name="maintenanceReportId">The maintenance report id.</param>
        IList<MaintenanceReportInstrumentDetailData> GetInstrumentsByMaintenanceReport(int maintenanceReportId);

        /// <summary>
        /// Reads all courier.
        /// </summary>
        ConfigurableListDataContract ReadAllConfigurableCourier(int facilityId);

        /// <summary>
        /// Reads all repair category.
        /// </summary>
        IList<RepairCategoryData> ReadAllRepairCategory();

        /// <summary>
        /// Creates the maintenance report.
        /// </summary>
        /// <param name="maintenanceReportPara">The maintenance report para.</param>
        int CreateMaintenanceReport(MaintenanceReportData maintenanceReportPara, List<MaintenanceReportInstrumentDetailData> instruments);

        /// <summary>
        /// Updates the maintenance report.
        /// </summary>
        /// <param name="maintenanceReportPara">The maintenance report para.</param>
        OperationResponseContract UpdateMaintenanceReport(MaintenanceReportData maintenanceReportPara, List<MaintenanceReportInstrumentDetailData> instruments);

        /// <summary>
        /// Reads all maintenance report status.
        /// </summary>
        IList<MaintenanceReportStatusData> ReadAllMaintenanceReportStatus();

        /// <summary>
        /// Reads maintenance report status by Maintenance Type.
        /// </summary>
        IList<MaintenanceReportStatusData> ReadMaintenanceReportStatusByMaintenanceType(int maintenanceTypeId);

        /// <summary>
        /// Get Maintenance Report Audit History by MaintenanceReportAuditHistory Id
        /// </summary>
        IList<MaintenanceReportAuditHistoryData> GetMaintenanceReportAuditHistoryByMaintenanceReportId(int maintenanceReportId);

        /// <summary>
        /// To retrieve View Or Close Maintenance Report
        /// </summary>
        IList<MaintenanceReportData> ReadMaintainenceReports(short facilityId, bool? isClose, bool? isCancelled, Synergy.Core.Data.DataFilter filter, int turnaroundId, int containerInstanceId, int userId, string userTimeZone, UserCultureData userCultureData);

        /// <summary>
        /// Updates the maintenance report.
        /// </summary>
        /// <param name="maintenanceReportPara">The maintenance report para.</param>
        OperationResponseContract PrintMaintenanceReport(int maintenanceReportId, int userId, UserCultureData userCultureData, bool localPrintingEnabled = false);
        IList<GenericKeyValueData> GetDefectItemDetailsForManintenance(CustomerDefectAssociationType customerDefectAssociationType, string itemId, short facilityId);

        /// <summary>
        /// Get Schedules By Customer.
        /// </summary>
        IList<ScheduleData> GetSchedulesByCustomer(int customerId);
        IList<CommentData> ReadMaintenanceReportComments(int maintenanceReportId);
        MaintenanceReportData CreateMaintenanceReportComment(int maintenanceReportId, int createdBy, string text);

        /// <summary>
        /// To check if planned maintenance for instance is due to be processed.
        /// </summary>
        bool IsPlannedMaintenanceScheduled(int instanceId, int turnaroundId);

        /// <summary>
        /// Get Maintenance Report Instrument List.
        /// </summary>
        IList<MaintenanceReportInstrumentListData> GetMaintenanceReportInstrumentList(int maintenanceReportId, int turnaroundID);

        /// <summary>
        /// Get Maintenance Report Instrument Details.
        /// </summary>
        IList<MaintenanceReportInstrumentListData> GetMaintenanceReportInstrumentDetails(int maintenanceReportId, int itemMasterId, int activityId);

        /// <summary>
        /// Update Maintenance Report Instrument Detail.
        /// </summary>
        int UpdateMaintenanceReportInstrumentDetail(MaintenanceReportInstrumentListData instrumentData);

        /// <summary>
        /// Read Maintenance Instrument Status.
        /// </summary>
        IList<KeyValuePair<int, string>> ReadMaintenanceInstrumentStatus();

        /// <summary>
        /// Create Maintenance Report Instrument Detail.
        /// </summary>
        int CreateMaintenanceReportInstrumentDetail(MaintenanceReportInstrumentListData instrumentData);

        /// <summary>
        /// Remove Maintenance Report Instrument Detail.
        /// </summary>
        bool RemoveMaintenanceReportInstrumentDetail(int maintenanceReportInstrumentId);
        bool RemoveMaintenanceReportInstrumentDetailWithStockMovement(int maintenanceReportInstrumentId, int userId, int returnStockLocationId, int itemMasterDefinitionId);

        /// <summary>
        /// Validate Maintenance Instrument Status.
        /// </summary>
        bool IsMaintenanceInstrumentStatusOpen(int maintenanceReportId);

        /// <summary>
        /// Check if PLanned Maintenance Flag has been setup for the facility selected.
        /// </summary>
        bool IsPlannedMaintenanceFlagSet(int facilityId);

        /// <summary>
        /// Method to print maintenance report list
        /// </summary>
        OperationResponseContract PrintMaintainenceReports(short facilityId, bool? isClose, bool? isCancelled, int userId, int turnaroundId, int containerInstanceId, Synergy.Core.Data.DataFilter filter, UserCultureData userCultureData, bool localPrintingEnabled = false);
        MaintenanceReportSetting GetMaintenanceReportSetting(int ownerId, MaintenanceTypeIdentifier? type);
        MaintenanceReportSetting GetMaintenanceReportSettingByCustomerDefinition(int custDefIdId, MaintenanceTypeIdentifier? type);
        MaintenanceReportSetting GetMaintenanceReportSettingByTurnaround(int turnaroundId, MaintenanceTypeIdentifier? type);
        MaintenanceReportSetting GetMaintenanceReportSettingByContainerInstance(int containerInstanceId, MaintenanceTypeIdentifier? type);
        IList<OwnerMaintenanceReportSettingDataContract> GetAllMaintenanceReportSettings(int ownerId);
        IList<OwnerMaintenanceReportSettingDataContract> GetAllMaintenanceReportSettingsByCustomerDefinition(int custDefId);
        int UpdateMaintenanceReportSettingByCustomerDefinition(int customerDefinitionId, MaintenanceTypeIdentifier? maintenanceTypeId, MaintenanceReportSetting maintenanceReportSetting, int userId);
        bool UpdateContainerMasterDefinitionMaintenanceCapacities(int userId, int containerMasterId, int? minimumInCirculation, int? maximumInMaintenance);
        List<ContainerMasterDefinitionMaintenanceCapacityData> GetContainerMasterDefinitionMaintenanceCapacities(int containerMasterDefinitionId);
    }
}
