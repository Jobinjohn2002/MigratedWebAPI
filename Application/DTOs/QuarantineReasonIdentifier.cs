using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum QuarantineReasonIdentifier
    {
        [EnumMember]
        [Description("Missing item on tray")]
        MissingItemOnTray = 1,

        [EnumMember]
        [Description("Decontamination")]
        Decontamination = 2,

        [EnumMember]
        [Description("Item requires repair")]
        ItemRequiresRepair = 3,

        [EnumMember]
        [Description("Missing item")]
        MissingItem = 4,

        [EnumMember]
        [Description("Extra item")]
        ExtraItem = 5,

        [EnumMember]
        [Description("Bar code tag not returned")]
        BarCodeTagNotReturned = 6,

        [EnumMember]
        [Description("Service report received see supervisor in charge")]
        ServiceReportReceived = 7,

        [EnumMember]
        [Description("Quarantine")]
        Quarantine = 8,

        [EnumMember]
        [Description("Item requires repair returned to customer")]
        ItemRequiresRepairReturnedToCustomer = 9,

        [EnumMember]
        [Description("Item requires repair sent to repair contractor")]
        ItemRequiresRepairSentToRepairContractor = 10,

        [EnumMember]
        [Description("Missing item returned to customer")]
        MissingItemReturnedToCustomer = 11,

        [EnumMember]
        [Description("Awaiting customer advice")]
        AwaitingCustomerAdvice = 12,

        [EnumMember]
        [Description("Awaiting replacement item")]
        AwaitingReplacementItem = 13,

        [EnumMember]
        [Description("Being used for training")]
        BeingUsedForTraining = 14,

        [EnumMember]
        [Description("Being used for microbiological testing")]
        BeingUsedForMicrobiologicalTesting = 15,

        [EnumMember]
        [Description("Tray list being amended")]
        TrayListBeingAmended = 16,

        [EnumMember]
        [Description("Maintenance")]
        Maintenance = 17,

        [EnumMember]
        [Description("Cleaning")]
        Cleaning = 18,

        [EnumMember]
        [Description("Sharpening")]
        Sharpening = 19,

        [EnumMember]
        [Description("Replacement")]
        Replacement = 20,

        [EnumMember]
        [Description("Repair")]
        Repair = 21,

        [EnumMember]
        [Description("Manual quarantine")]
        ManualQuarantine = 22,

        [EnumMember]
        [Description("The item is assigned to another tray")]
        TheItemIsAssignedToAnotherTray = 23,

        [EnumMember]
        [Description("Rejected Items Require Rewash")]
        RejectedItemsRequireRewash = 24,

        [EnumMember]
        [Description("Tray added to failed batch")]
        TrayAddedToFailedBatch = 25,

        [EnumMember]
        [Description("Tray requires BI")]
        TrayRequiresBI = 26,

        [EnumMember]
        [Description("BI Failed")]
        BIFailed = 27,

        [EnumMember]
        [Description("Batch Failed")]
        BatchFailed = 28,

        [EnumMember]
        [Description("Not Assigned a Batch")]
        NotAssignedABatch = 29,

        [EnumMember]
        [Description("Planned Maintenance")]
        PlannedMaintenance = 30,

        [EnumMember]
        [Description("Weight Check Failed")]
        WeightCheckFailed = 31,

        [EnumMember]
        [Description("Audit Failed")]
        AuditFailure = 33,

        [EnumMember]
        [Description("CSR Raised")]
        CSRRaised = 35,

        [EnumMember]
        [Description("Service Report Raised")]
        ServiceReportRaised = 36,

        [EnumMember]
        [Description("Imported Draft")]
        ImportedDraft = 37,

        [EnumMember]
        [Description("External Request")]
        ExternalRequest = 38,

        [EnumMember]
        [Description("Pre-AER tasks failed")]
        PreAerTasksFailed = 134,

        /// Warning: do not create enums higher than 1000
        /// <summary>
        /// Enums greater than or equal to 1000 are reserved for user created values
        /// </summary>
        //[EnumMember]
        //[Description("User Created Values")]
        //UserCreatedValue = 1000++ // Invalid syntax.  Cannot increment in declaration.
    }
}