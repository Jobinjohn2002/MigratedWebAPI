using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SynergyApplicationFrameworkApi.Application.Services
{
#pragma warning disable S2068 //Hard-coded Password, none are actual passwords
    public static class KnownTenancySetting
    {
        public const string TestSetting = "TestSetting";
        public const string Currency_Unit = "Currency_Unit";
        public const string Defect_Turnaround_Enabled = "Defect_Turnaround_Enabled";
        public const string Defect_Position_Enabled = "Defect_Position_Enabled";
        public const string Defect_Department_Enabled = "Defect_Department_Enabled";
        public const string Defect_Source_Enabled = "Defect_Source_Enabled";
        public const string Defect_UnTrackedProduct_Enabled = "Defect_UnTrackedProduct_Enabled";
        public const string Defect_UnTrackedProduct_AlternateId_Enabled = "Defect_UnTrackedProduct_AlternateId_Enabled";
        public const string Defect_UnTrackedProduct_Description_Enabled = "Defect_UnTrackedProduct_Description_Enabled";
        public const string Defect_UnTrackedProduct_LotNumber_Enabled = "Defect_UnTrackedProduct_LotNumber_Enabled";
        public const string Forgotten_Password_Email_Token_Expiry = "Forgotten_Password_Email_Token_Expiry";
        public const string Default_User_Context = "Default_User_Context";
        public const string AllowTurnaroundRevisionUpdateUptoAutoclave = "Allow_Turnaround_Revision_Update_Upto_Autoclave";
        public const string Reset_Password_Email_Token_Expiry = "Reset_Password_Email_Token_Expiry";
        public const string Contact_Phone_Number = "Contact_Phone_Number";
        public const string Contact_Email_Address = "Contact_Email_Address";
        public const string Contact_URL = "Contact_URL";

        public const string ContactPhoneNumberAdmin = "Contact_Phone_Number_Admin";
        public const string ContactEmailAddressAdmin = "Contact_Email_Address_Admin";
        public const string ContactURLAdmin = "Contact_URL_Admin";
        public const string ContactOpeningHourAdmin = "Contact_Opening_Hour_Admin";
        public const string ContactClosingHourAdmin = "Contact_Closing_Hour_Admin";
        public const string ContactTimezoneAdmin = "Contact_Timezone_Admin";
        public const string DashboardEnabled = "Module_Dashboard_Enabled";
        public const string ReportingEnabled = "Module_Reporting_Enabled";

        public const string OrdersOption = "Module_Orders_Option";
        public const string OrderMinimumNotice = "Orders_Minimum_Notice";
        public const string OrderFulfillmentWindowBefore = "Orders_Fulfillment_Window_Before";
        public const string OrderFulfillmentWindowAfter = "Orders_Fulfillment_Window_After";
        public const string ForceOrderToMatchTurnaroundDeliveryPoint = "Force_Order_To_Match_Turnaround_Delivery_Point";

        public const string TurnaroundEnabled = "Module_Turnarounds_Enabled";
        public const string TurnaroundUsageEnabled = "Module_Turnarounds_Usage_Enabled";

        public const string FastTracksEnabled = "Module_FastTracks_Enabled";
        public const string FastTrackRequiredDateEnabled = "Module_FastTracks_RequiredDate_Enabled";

        public const string ChangeRequestsEnabled = "Module_ChangeRequests_Enabled";

        public const string CustomerDefectsEnabled = "Module_CustomerDefects_Enabled";

        public const string DefectsEnabled = "Module_Defects_Enabled";
        public const string MaintenanceEnabled = "Module_Maintenance_Enabled";

        public const string EnquiriesEnabled = "Module_Enquiries_Enabled";

        public const string LoanKitsEnabled = "Module_LoanKits_Enabled";

        public const string StoragePointsEnabled = "Module_StoragePoints_Enabled";

        public const string EPOCEnabled = "Module_EPOC_Enabled";
        public const string EPOCLoadTrolleyEnabled = "Module_EPOC_LoadTrolley_Enabled";
        public const string EPOCMakeAvailableEnabled = "Module_EPOC_MakeAvailable_Enabled";
        public const string EPOCCollectEnabled = "Module_EPOC_Collect_Enabled";
        public const string EPOCLoadFromUsagePointEnabled = "Module_EPOC_LoadFromUsagePoint_Enabled";

        public const string EPODEnabled = "Module_EPOD_Enabled";
        public const string EPODDeliverEnabled = "Module_EPOD_Deliver_Enabled";
        public const string EPODStockTransferEnabled = "Module_EPOD_StockTransfer_Enabled";
        public const string EPODStockTransferCustomerGroupEnabled = "Module_EPOD_StockTransfer_CustomerGroup_Enabled";

        public const string InstanceEnabled = "Module_Instances_Enabled";

        public const string AllowQAReprintingAtEnquiry = "Allow_QA_Reprinting_At_Enquiry";
        public const string PrintQALabelsAlphabetically = "Print_QA_Labels_Alphabetically";

        public const string FastTrackLightEnabled = "Fast_Track_Light_Request_Enabled";
        public const string FastTrackLightAlias = "Fast_Track_Light_Request_Alias";

        public const string InstrumentGlobalCatalogueRelatedImagesEnabled = "Instrument_Global_Catalogue_Related_Images_Enabled";
        public const string TargetSite = "Tableau_Target_Site";

        public const string SurgicalProceduresEnabled = "Module_SurgicalProcedures_Enabled";
        public const string PreferredCulture = "Preferred_Culture";
        public const string PasswordAttemptsLimit = "Password_Attempts_Limit";
        public const string PasswordExpirationTimeDays = "Password_Expiry_Days";
        public const string PasswordPreviousToCheck = "Password_Previous_To_Check";
        public const string PasswordPolicyEnforcedOnCustomers = "Password_Policy_Enforced_On_Customers";
        public const string PasswordBreachPolicyEnabled = "Have_I_Been_Pwned_Check";
        public const string PasswordBreachPolicyEnforcedOnCustomers = "Password_Breach_Policy_Enforced_On_Customers";
        public const string PasswordBreachCountLimit = "Have_I_Been_Pwned_Breach_Count_Tolerance";
        public const string PasswordBreachCountLimitForCustomer = "Password_Breach_Count_Limit_For_Customer";

        public const string StockSterileExpiryWarningMinutes = "Module_Stock_Sterile_Warning_Minutes";
        public const string LoadFromUsagePointStockCountWarning = "Load_From_Usage_Point_Stock_Count_Warning";
        public const string LoanSetAPIDeliveryDateMinutes = "LoanSet_API_Delivery_Date_Minutes";
        public const string LoanSetAPIReturnDateMinutes = "LoanSet_API_Return_Date_Minutes";
        public const string LoanSetAPIMinimumTrayReprocessingTimeMinutes = "LoanSet_API_Minimum_Tray_Reprocessing_Time_Minutes";
        public const string LoanSetAPIMinimumTrayAdditionTimeMinutes = "LoanSet_API_Minimum_Tray_Addition_Time_Minutes";
        public const string IMSMaintenanceAPIQuarantineEvents = "IMS_Maintenance_API_Quarantine_Events";
        public const string IMSMaintenanceAPIVendorId = "IMS_Maintenance_API_Vendor_Id";
        public const string QueryIntelligencePortalEnabled = "Query_Intelligence_Portal_Enabled";
        public const string QueryIntelligenceAdminEnabled = "Query_Intelligence_Admin_Enabled";
        public const string MobileDefaultTemporaryOfflineTimeMinutes = "Mobile_Default_Temporary_Offline_Time_Minutes";
        public const string MobileMaximumTemporaryOfflineTimeMinutes = "Mobile_Maximum_Temporary_Offline_Time_Minutes";

        public const string MarketingFrontPageEnabled = "Marketing_Front_Page_Enabled";

    }
#pragma warning restore S2068 //Hard-coded Password, none are actual passwords
}
