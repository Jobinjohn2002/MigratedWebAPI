using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// KnownFacilitySetting
    /// </summary>
    public class KnownFacilitySetting
    {
        public const string TestSetting = "TestSetting";
        public const string LocalPrinting = "Local_Printing_Enabled";
        public const string OrderMinimumNotice = "Orders_Minimum_Notice";
        public const string ForceOrderToMatchTurnaroundDeliveryPoint = "Force_Order_To_Match_Turnaround_Delivery_Point";
        public const string WorkaroundForGS1BarcodeEnabled = "Workaround_For_GS1_Barcode";
        public const string RetrospectiveAutoclaveApproval = "Retro_Autoclave_Approval_Enabled";
        public const string RetroAutoclaveCancelEnabled = "Retro_Autoclave_Cancel_Enabled";
        public const string EndTurnaroundButtonEnabled = "End_Turnaround_Button_Enabled";
        public const string AutomaticDispatchEnabled = "Automatic_Dispatch_Enabled";
        public const string AutomaticDeliveryNotePrintEnabled = "Automatic_Delivery_Note_Print_Enabled";
        public const string AbandonExtrasTime = "Abandon_Extras_Time";
        public const string ExceptionInstrumentReturnsEnabled = "Exceptional_Instrument_Returns_Enabled";
        public const string OperativeCreateInstanceShowChargeableDialog = "Operative_Create_Instance_Show_Chargeable_Dialog";
        public const string NonTrackableInstancesEnabled = "Non_Trackable_Instances_Enabled";
        public const string ManageServiceRequirementsInAdminDisabled = "Manage_Service_Requirements_In_Admin_Disabled";
        public const string OperativeDuplicateScanExclusionTimeMs = "Operative_Duplicate_Scan_Exclusion_Time_Ms";
        public const string OperativeDifferentDeliveryPointBatchTagWarning = "Operative_Different_DeliveryPoint_BatchTag_Warning";
        public const string OperativeDifferentDeliveryPointDispatchWarning = "Operative_Different_DeliveryPoint_Dispatch_Warning";
        public const string AllowAutomaticDispatch = "Allow_Automatic_Dispatch";
        public const string AutomaticCompleteTurnaroundForStockOrderingEnabled = "Automatic_Complete_Turnaround_For_StockOrdering_Enabled";
        public const string PreferredCulture = "Preferred_Culture";
        public const string SingleSignOnEnabled = "Single_Sign_On_Enabled";
        public const string UseDateBasedBatchIdFormat = "Use_Date_Based_BatchId_Format";
        public const string DateBasedBatchIdFormat = "Date_Based_BatchId_Format";
        public const string FinishPackingWithoutScan = "Finish_Packing_Without_Scan";
        public const string ShowAuditWarningAssigningToBatchTag = "Show_Audit_Warning_Assigning_To_BatchTag";
        public const string InspectionAssemblyAutoHideCompleted = "Inspection_Assembly_Auto_Hide_Completed";
        public const string SecurityTokenLifespanSeconds = "Security_Token_Lifespan_Seconds";
        public const string OrderingEnabled = "Ordering_Enabled";
        public const string DeconAuditImmediateQuarantine = "Decon_Audit_Immediate_Quarantine";
        public const string ShowBatchIdAtWash = "Show_batch_Id_at_wash";
        public const string AllowSelectionOfExistingWashBatch = "Allow_Selection_Of_Existing_Wash_Batch";
        public const string EndoscopeSterileExpiryAerPassedMinutes = "Endoscope_Sterile_Expiry_AER_Passed_Minutes";
        public const string EndoscopeSterileExpiryRemovedFromDryingCabinetWetMinutes = "Endoscope_Sterile_Expiry_Removed_From_Drying_Cabinet_Wet_Minutes";
        public const string EndoscopeSterileExpiryRemovedFromDryingCabinetDryMinutes = "Endoscope_Sterile_Expiry_Removed_From_Drying_Cabinet_Dry_Minutes";
        public const string EndoscopeAboutToExpireWarningMinutes = "Endoscope_About_To_Expire_Warning_Minutes";
        public const string EndoscopeRemovedWetRelaxedExpiryRules = "Endoscope_Removed_Wet_Relaxed_Expiry_Rules";
        public const string RewashSupervisorApprovalRequired = "Rewash_Supervisor_Approval_Required";
        public const string AutoUpdateInstaller = "Auto_Update_Installer";
        public const string TrolleyDispatchAboutToExpireWarningMinutes = "Trolley_Dispatch_About_To_Expire_Warning_Minutes";
        public const string OrderInspectionAndAssemblyByPriorityStationIds = "Order_Inspection_And_Assembly_By_Priority_StationIds";
        public const string FastTrackPMCardDisabled = "FastTrack_PMCard_Disabled";
        public const string FacilityTransferTrolley = "Facility_Transfer_Trolley_Enabled";
        public const string FacilityStockDispatchEnabled = "Facility_Stock_Dispatch_Enabled";
        public const string DispatchWithoutTrolleySetting = "Dispatch_Without_Trolley_Enabled";
        public const string IsSterileExpiryColumnEnabled = "SterileExpiry_PMColumn_Enabled";
        public const string IsSortByPriorityEnabled = "Priority_PMSort_Enabled";
        public const string PriorityTimeWindowHours = "Priority_Time_Window_Hours";
        public const string ProductionManagerShowContractuallyEnded = "Production_Manager_Show_Contractually_Ended";
        public const string SignalREnabled = "SignalR_Enabled";
        public const string SignalRAdminEnabled = "SignalR_Admin_Enabled";
        public const string SignalROperativeEnabled = "SignalR_Operative_Enabled";
        public const string AuditRequiresAllItemsChecked = "Audit_Requires_All_Items_Checked";
        public const string InstrumentGlobalCatalogueRelatedImagesEnabled = "Instrument_Global_Catalogue_Related_Images_Enabled";
        public const string AuditStationExceptions = "Audit_Station_Exceptions";
        public const string LoanSetAPIDeliveryDateMinutes = "LoanSet_API_Delivery_Date_Minutes";
        public const string LoanSetAPIReturnDateMinutes = "LoanSet_API_Return_Date_Minutes";
        public const string LoanSetAPICreateOrderOnLoanKitRequestCreation = "LoanSet_API_Create_Order_On_Loan_Kit_Request_Creation";
        public const string LoanSetAPIMinimumTrayReprocessingTimeMinutes = "LoanSet_API_Minimum_Tray_Reprocessing_Time_Minutes";
        public const string LoanSetAPIMinimumTrayAdditionTimeMinutes = "LoanSet_API_Minimum_Tray_Addition_Time_Minutes";
        public const string ZimmerInventoryCaseQuarantineEvents = "Zimmer_Inventory_Case_Quarantine_Events";
        public const string IMSMaintenanceAPIQuarantineEvents = "IMS_Maintenance_API_Quarantine_Events";
        public const string IMSMaintenanceAPIVendorId = "IMS_Maintenance_API_Vendor_Id";
    }
}
