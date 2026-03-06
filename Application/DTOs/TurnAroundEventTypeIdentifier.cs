using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public enum TurnAroundEventTypeIdentifier
    {
        [EnumMember(Value = "Unknown")]
        Unknown = 0,

        [Description("Inbound")]
        [EnumMember(Value = "Inbound")]
        Inbound = 1,

        [Description("Wash")]
        [EnumMember(Value = "Wash")]
        Wash = 2,

        [Description("Tray Prioritisation")]
        [EnumMember(Value = "TrayPrioritisation")]
        TrayPrioritisation = 3,

        [Description("Quality Assurance")]
        [EnumMember(Value = "QualityAssurance")]
        QualityAssurance = 5,

        [Description("Into Autoclave")]
        [EnumMember(Value = "IntoAutoclave")]
        IntoAutoclave = 6,

        [Description("Out of Autoclave")]
        [EnumMember(Value = "OutofAutoclave")]
        OutofAutoclave = 7,

        [Description("Dispatch")]
        [EnumMember(Value = "Dispatch")]
        Dispatch = 8,

        [Description("Delivery Note Print")]
        [EnumMember(Value = "DeliveryNotePrint")]
        DeliveryNotePrint = 9,

        [Description("Reprint Tray List")]
        [EnumMember(Value = "ReprintTrayList")]
        ReprintTrayList = 10,

        [Description("Failed Autoclave")]
        [EnumMember(Value = "FailedAutoclave")]
        FailedAutoclave = 11,

        [Description("Removed From Delivery Note")]
        [EnumMember(Value = "RemovedFromDeliveryNote")]
        RemovedFromDeliveryNote = 13,

        [Description("Into Stock")]
        [EnumMember(Value = "IntoStock")]
        IntoStock = 14,

        [Description("Out Of Stock")]
        [EnumMember(Value = "OutOfStock")]
        OutOfStock = 15,

        [Description("Inbound With Incorrect Specification")]
        [EnumMember(Value = "InboundWithIncorrectSpecification")]
        InboundWithIncorrectSpecification = 16,

        [Description("Into Quarantine")]
        [EnumMember(Value = "IntoQuarantine")]
        IntoQuarantine = 17,

        [Description("Pass Warning")]
        [EnumMember(Value = "PassWarning")]
        PassWarning = 18,

        [Description("Out Of Quarantine")]
        [EnumMember(Value = "OutOfQuarantine")]
        OutOfQuarantine = 19,

        [Description("Archived")]
        [EnumMember(Value = "Archived")]
        Archived = 20,

        [Description("Added to summary")]
        [EnumMember(Value = "Addedtosummary")]
        Addedtosummary = 21,

        [Description("Failed Wash")]
        [EnumMember(Value = "FailedWash")]
        FailedWash = 22,

        [Description("Failed Quality Assurance")]
        [EnumMember(Value = "FailedQualityAssurance")]
        FailedQualityAssurance = 23,

        [Description("Override Cooldown")]
        [EnumMember(Value = "OverrideCooldown")]
        OverrideCooldown = 24,

        [Description("Facility Open")]
        [EnumMember(Value = "FacilityOpen")]
        FacilityOpen = 25,

        [Description("Facility Close")]
        [EnumMember(Value = "FacilityClose")]
        FacilityClose = 26,

        [Description("Delivered")]
        [EnumMember(Value = "Delivered")]
        Delivered = 27,

        [Description("Available For Collection")]
        [EnumMember(Value = "AvailableForCollection")]
        AvailableForCollection = 28,

        [Description("Collected")]
        [EnumMember(Value = "Collected")]
        Collected = 29,

        [Description("Manual Proof of Delivery")]
        [EnumMember(Value = "ManualProofofDelivery")]
        ManualProofofDelivery = 30,

        [Description("Inspection")]
        [EnumMember(Value = "Inspection")]
        Inspection = 31,

        [Description("Into Pigeon Hole/Stock")]
        [EnumMember(Value = "IntoPigeonHoleStock")]
        IntoPigeonHoleStock = 32,

        [Description("Rewash")]
        [EnumMember(Value = "Rewash")]
        Rewash = 33,

        [Description("Repair")]
        [EnumMember(Value = "Repair")]
        Repair = 34,

        [Description("To Be Condemned")]
        [EnumMember(Value = "ToBeCondemned")]
        ToBeCondemned = 35,

        [Description("Send For Reinspection")]
        [EnumMember(Value = "SendForReinspection")]
        SendForReinspection = 36,

        [Description("Assisted Inspection")]
        [EnumMember(Value = "AssistedInspection")]
        AssistedInspection = 37,

        [Description("Respot")]
        [EnumMember(Value = "Respot")]
        Respot = 38,

        [Description("On Order")]
        [EnumMember(Value = "OnOrder")]
        OnOrder = 39,

        [Description("Non Steam Sterilisation")]
        [EnumMember(Value = "NonSteamSterilisation")]
        NonSteamSterilisation = 40,

        [Description("Load Trolley")]
        [EnumMember(Value = "LoadTrolleyEPOC")]
        LoadTrolleyEPOC = 41,

        [Description("Return From Quarantine")]
        [EnumMember(Value = "ReturnFromQuarantine")]
        ReturnFromQuarantine = 42,

        [Description("Automatic Delivery")]
        [EnumMember(Value = "AutomaticDelivery")]
        AutomaticDelivery = 43,

        [Description("Transfer")]
        [EnumMember(Value = "Transfer")]
        Transfer = 44,

        [Description("Service Requirement Change")]
        [EnumMember(Value = "ServiceRequirementChange")]
        ServiceRequirementChange = 45,

        [Description("Reprint Label")]
        [EnumMember(Value = "ReprintLabel")]
        ReprintLabel = 46,

        [Description("End Packing")]
        [EnumMember(Value = "EndPacking")]
        EndPacking = 47,

        [Description("Cancel Packing")]
        [EnumMember(Value = "PackingCancelled")]
        PackingCancelled = 48,

        [Description("Quarantine Override")]
        [EnumMember(Value = "QuarantineOverride")]
        QuarantineOverride = 49,

        [Description("Into Wash")]
        [EnumMember(Value = "IntoWash")]
        IntoWash = 50,

        [Description("Wet Pack")]
        [EnumMember(Value = "WetPack")]
        WetPack = 51,

        [Description("Broken Pack")]
        [EnumMember(Value = "BrokenPack")]
        BrokenPack = 52,

        [Description("Item Exception Updated")]
        [EnumMember(Value = "ItemExceptionUpdated")]
        ItemExceptionUpdated = 53,

        [Description("Receive Stock")]
        [EnumMember(Value = "ReceiveStock")]
        ReceiveStock = 54,

        [Description("Issued to End User")]
        [EnumMember(Value = "IssuedtoEndUser")]
        IssuedtoEndUser = 55,

        [Description("Returned from End User")]
        [EnumMember(Value = "ReturnedfromEndUser")]
        ReturnedfromEndUser = 56,

        [Description("Un Pack")]
        [EnumMember(Value = "UNPack")]
        UNPack = 57,

        [Description("Print Decontamination Certificate")]
        [EnumMember(Value = "PrintDecontaminationCertificate")]
        PrintDecontaminationCertificate = 58,

        [Description("Customer Defect Raised")]
        [EnumMember(Value = "CustomerDefectRaised")]
        CustomerDefectRaised = 59,

        [Description("Customer Defect Responded")]
        [EnumMember(Value = "CustomerDefectResponded")]
        CustomerDefectResponded = 60,

        [Description("Customer Defect Closed")]
        [EnumMember(Value = "CustomerDefectClosed")]
        CustomerDefectClosed = 61,

        [Description("Customer Defect Reopen")]
        [EnumMember(Value = "CustomerDefectReopen")]
        CustomerDefectReopen = 62,

        [Description("Confirmed As Sterile")]
        [EnumMember(Value = "ConfirmedAsSterile")]
        ConfirmedAsSterile = 63,

        [Description("Acknowledged Note")]
        [EnumMember(Value = "AcknowledgeNote")]
        AcknowledgeNote = 64,

        [Description("Independent Second Check Required")]
        [EnumMember(Value = "IndependentSecondCheckRequired")]
        IndependentSecondCheckRequired = 66,

        [Description("Removed From Batch")]
        [EnumMember(Value = "RemovedFromBatch")]
        RemovedFromBatch = 67,

        [Description("Fail Batch Pre-Steam Injection")]
        [EnumMember(Value = "FailBatchPreSteamInjectionWithReassign")]
        FailBatchPreSteamInjectionWithReassign = 68,

        [Description("Fail Batch Post-Steam Injection")]
        [EnumMember(Value = "FailBatchPostSteamInjection")]
        FailBatchPostSteamInjection = 69,

        [Description("Fail Presteam Batch -  Without Reassign")]
        [EnumMember(Value = "FailBatchPreSteamInjectionWithoutReassign")]
        FailBatchPreSteamInjectionWithoutReassign = 70,

        [Description("Batch Reassigned")]
        [EnumMember(Value = "ReassignBatch")]
        ReassignBatch = 71,

        [Description("Wash Process Created")]
        [EnumMember(Value = "WashProcessCreated")]
        WashProcessCreated = 72,

        [Description("Assign to Wash Process Tag")]
        [EnumMember(Value = "AssigntoWashProcessTag")]
        AssigntoWashProcessTag = 73,

        [Description("Wash - Release Required")]
        [EnumMember(Value = "WashRequireRelease")]
        WashRequireRelease = 74,

        [Description("Wash Released")]
        [EnumMember(Value = "WashRelease")]
        WashRelease = 75,

        [Description("Legacy Instance Barcode Replaced")]
        [EnumMember(Value = "LegacyInstanceBarcodeReplaced")]
        LegacyInstanceBarcodeReplaced = 76,

        [Description("Failed Wash(Release Required)")]
        [EnumMember(Value = "FailedWashReleaseRequired")]
        FailedWashReleaseRequired = 77,

        [Description("Failed Packing")]
        [EnumMember(Value = "FailedPacking")]
        FailedPacking = 78,

        [Description("Reprint Instance Barcode")]
        [EnumMember(Value = "ReprintInstanceBarcode")]
        ReprintInstanceBarcode = 79,

        [Description("Part Wash")]
        [EnumMember(Value = "PartWash")]
        PartWash = 80,

        [Description("Reprinted Delivery Note")]
        [EnumMember(Value = "ReprintedDeliveryNote")]
        ReprintedDeliveryNote = 81,

        [Description("Assigned to Batch Tag")]
        [EnumMember(Value = "AssignToBatchTag")]
        AssignToBatchTag = 82,

        [Description("Removed From Batch Tag")]
        [EnumMember(Value = "RemoveFromBatchTag")]
        RemoveFromBatchTag = 83,

        [Description("Removed from Invoice")]
        [EnumMember(Value = "RemovedFromInvoice")]
        RemovedFromInvoice = 84,

        [Description("Load Trolley EPOD")]
        [EnumMember(Value = "LoadTrolleyEPOD")]
        LoadTrolleyEPOD = 85,

        [Description("Batch Tag Created")]
        [EnumMember(Value = "BatchTagCreated")]
        BatchTagCreated = 86,

        [Description("Removed From Wash Process Tag")]
        [EnumMember(Value = "RemoveFromWashProcessTag")]
        RemoveFromWashProcessTag = 87,

        [Description("Automatic Collection")]
        [EnumMember(Value = "AutomaticCollection")]
        AutomaticCollection = 88,

        [Description("Automatic Inbound")]
        [EnumMember(Value = "AutomaticInbound")]
        AutomaticInbound = 89,

        [Description("Into Autoclave (Added in error)")]
        [EnumMember(Value = "IntoAutoclaveAddedInError")]
        IntoAutoclaveAddedInError = 90,

        [Description("Tray Prioritisation End")]
        [EnumMember(Value = "TrayPrioritisationEnd")]
        TrayPrioritisationEnd = 100,

        [Description("Wash Start")]
        [EnumMember(Value = "WashStart")]
        WashStart = 101,

        [Description("QA Start")]
        [EnumMember(Value = "QAStart")]
        QAStart = 102,

        [Description("Carriage Created")]
        [EnumMember(Value = "CarriageCreated")]
        CarriageCreated = 103,

        [Description("Assigned to Carriage")]
        [EnumMember(Value = "AssignedToCarriage")]
        AssignedToCarriage = 104,

        [Description("Removed from Carriage")]
        [EnumMember(Value = "RemovedFromCarriage")]
        RemovedFromCarriage = 105,

        [Description("Wash In")]
        [EnumMember(Value = "WashIn")]
        WashIn = 106,

        [Description("Packing Started")]
        [EnumMember(Value = "StartPacking")]
        StartPacking = 107,

        [Description("Packing Finished")]
        [EnumMember(Value = "FinishPacking")]
        FinishPacking = 108,

        [Description("Packing Cancelled")]
        [EnumMember(Value = "CancelPacking")]
        CancelPacking = 109,

        [Description("Packing Failed")]
        [EnumMember(Value = "FailPacking")]
        FailPacking = 110,

        [Description("Changed Batch")]
        [EnumMember(Value = "ChangedBatch")]
        ChangedBatch = 111,

        [Description("Biological Indicator Failed")]
        [EnumMember(Value = "BiologicalIndicatorFailed")]
        BiologicalIndicatorFailed = 112,

        [Description("Planned Maintenance Check")]
        [EnumMember(Value = "PlannedMaintenanceChecked")]
        PlannedMaintenanceChecked = 113,

        [Description("Planned Maintenance Warning")]
        [EnumMember(Value = "PlannedMaintenanceWarned")]
        PlannedMaintenanceWarned = 114,

        [Description("Order Shipped")]
        [EnumMember(Value = "OrderShipped")]
        OrderShipped = 115,

        [Description("Removed From Order")]
        [EnumMember(Value = "RemovedFromOrder")]
        RemovedFromOrder = 116,

        [Description("Added To Order")]
        [EnumMember(Value = "AddedToOrder")]
        AddedToOrder = 117,

        [Description("Packing Process Ended")]
        [EnumMember(Value = "PackingProcessEnded")]
        PackingProcessEnded = 118,

        [Description("Review Needed")]
        [EnumMember(Value = "ReviewNeeded")]
        ReviewNeeded = 119,

        [Description("Reviewed")]
        [EnumMember(Value = "Reviewed")]
        Reviewed = 120,

        [Description("Review Cancelled")]
        [EnumMember(Value = "ReviewCancelled")]
        ReviewCancelled = 121,

        [Description("Retrospective out of Autoclave Approval")]
        [EnumMember(Value = "RetrospectiveOutOfAutoclaveApproval")]
        RetrospectiveOutOfAutoclaveApproval = 122,

        [Description("Turnaround Ended Early")]
        [EnumMember(Value = "TurnaroundEndedEarly")]
        TurnaroundEndedEarly = 123,

        [Description("Facility Changed")]
        [EnumMember(Value = "ChangedFacility")]
        ChangedFacility = 124,

        [Description("Decontamination Start")]
        [EnumMember(Value = "DeconStart")]
        DeconStart = 130,

        [Description("Decontamination End")]
        [EnumMember(Value = "DeconEnd")]
        DeconEnd = 131,

        [Description("Decontamination Cancel")]
        [EnumMember(Value = "DeconCancel")]
        DeconCancel = 132,

        [Description("Out of Pigeon Hole/Stock")]
        [EnumMember(Value = "OutOfPigeonHoleStock")]
        OutOfPigeonHoleStock = 140,

        [Description("Automatic Dispatch")]
        [EnumMember(Value = "AutomaticDispatch")]
        AutomaticDispatch = 141,

        #region New Quarantine Event Types
        [Description("Reroute to Wash")]
        [EnumMember(Value = "RerouteToWash")]
        RerouteToWash = 150,

        [Description("Reroute to Inspection, Assembly and Packing")]
        [EnumMember(Value = "RerouteToInspectionAssemblyPacking")]
        RerouteToInspectionAssemblyPacking = 152,

        [Description("Reroute to Quality Assurance")]
        [EnumMember(Value = "RerouteToQualityAssurance")]
        RerouteToQualityAssurance = 153,

        [Description("Reroute to Into Autoclave")]
        [EnumMember(Value = "RerouteToIntoAutoclave")]
        RerouteToIntoAutoclave = 154,

        [Description("Reroute to Dispatch")]
        [EnumMember(Value = "RerouteToDispatch")]
        RerouteToDispatch = 155,

        [Description("Packing Resumed")]
        [EnumMember(Value = "PackingResumed")]
        PackingResumed = 156,

        [Description("Packing Paused")]
        [EnumMember(Value = "PackingPaused")]
        PackingPaused = 157,
        #endregion

        [Description("Added to Transfer Note")]
        [EnumMember(Value = "AddedToTransferNote")]
        AddedToTransferNote = 200,

        [Description("Removed from Transfer Note")]
        [EnumMember(Value = "RemovedFromTransferNote")]
        RemovedFromTransferNote = 201,

        [Description("Facility Transfer - Outbound")]
        [EnumMember(Value = "FacilityTransferOutbound")]
        FacilityTransferOutbound = 202,

        [Description("Facility Transfer - Inbound")]
        [EnumMember(Value = "FacilityTransferInbound")]
        FacilityTransferInbound = 203,

        [Description("Retrospective added to batch tag")]
        [EnumMember(Value = "RetrospectiveAddedToBatchTag")]
        RetrospectiveAddedToBatchTag = 210,

        [Description("Retrospective added to wash batch")]
        [EnumMember(Value = "RetrospectiveAddedToWashBatch")]
        RetrospectiveAddedToWashBatch = 211,

        [Description("Added to Surgical Procedure")]
        [EnumMember(Value = "AddToSurgicalProcedure")]
        AddToSurgicalProcedure = 212,

        [Description("Removed from Surgical Procedure")]
        [EnumMember(Value = "RemovedFromSurgicalProcedure")]
        RemovedFromSurgicalProcedure = 213,

        [Description("Automatic Start")]
        [EnumMember(Value = "AutomaticStart")]
        AutomaticStart = 214,

        [Description("Weighed (Using Pre-Wash Tolerances)")]
        [EnumMember(Value = "WeighedUsingPreWashTolerances")]
        WeighedUsingPreWashTolerances = 215,

        [Description("Weighed (Using Post-Wash Tolerances)")]
        [EnumMember(Value = "WeighedUsingPostWashTolerances")]
        WeighedUsingPostWashTolerances = 216,

        [Description("Specification Updated")]
        [EnumMember(Value = "SpecificationChanged")]
        SpecificationChanged = 217,

        [Description("Biological Indicator Incubation Failure")]
        [EnumMember(Value = "BiologicalIndicatorIncubationFailure")]
        BiologicalIndicatorIncubationFailure = 220,

        [Description("Audit Started")]
        [EnumMember(Value = "AuditStarted")]
        AuditStarted = 230,

        [Description("Audit Finished")]
        [EnumMember(Value = "AuditFinished")]
        AuditFinished = 231,

        [Description("Audit Failed")]
        [EnumMember(Value = "AuditFailed")]
        AuditFailed = 232,

        [Description("Audit Cancelled")]
        [EnumMember(Value = "AuditCancelled")]
        AuditCancelled = 233,

        [Description("Reprint")]
        [EnumMember(Value = "Reprint")]
        Reprint = 263,

        [Description("Fail Wash In")]
        [EnumMember(Value = "FailWashIn")]
        FailWashIn = 264,

        [Description("Restart Wash")]
        [EnumMember(Value = "RestartWash")]
        RestartWash = 265,

        [EnumMember(Value = "FailedWashPrintReport")]
        FailedWashPrintReport = 266,

        #region Mobile Offline Events

        [Description("Offline - Collected")]
        [EnumMember(Value = "OfflineCollected")]
        OfflineCollected = 261,

        [Description("Offline - Delivered")]
        [EnumMember(Value = "OfflineDelivered")]
        OfflineDelivered = 262,

        [Description("Offline - Into Pigeon Hole/Stock")]
        [EnumMember(Value = "OfflineIntoPigeonHoleStock")]
        OfflineIntoPigeonHoleStock = 267,

        [Description("Offline - Out of Pigeon Hole/Stock")]
        [EnumMember(Value = "OfflineOutOfPigeonHoleStock")]
        OfflineOutOfPigeonHoleStock = 268,

        [Description("Offline - Available For Collection")]
        [EnumMember(Value = "OfflineAvailableForCollection")]
        OfflineAvailableForCollection = 269,

        [Description("Offline - Load Trolley")]
        [EnumMember(Value = "OfflineLoadTrolley")]
        OfflineLoadTrolley = 270,

        [Description("Offline - Load Trolley EPOD")]
        [EnumMember(Value = "OfflineLoadTrolleyEPOD")]
        OfflineLoadTrolleyEPOD = 271,

        #endregion

        #region Endoscopy

        [Description("Into Drying Cabinet")]
        [EnumMember(Value = "IntoDryingCabinet")]
        IntoDryingCabinet = 250,

        [Description("Dispatch - Immediate Use")]
        [EnumMember(Value = "DispatchImmediateUse")]
        DispatchImmediateUse = 253,

        [Description("Removed from Drying Cabinet - Wet")]
        [EnumMember(Value = "RemovedFromDryingCabinetWet")]
        RemovedFromDryingCabinetWet = 255,

        [Description("Removed from Drying Cabinet - Dry")]
        [EnumMember(Value = "RemovedFromDryingCabinetDry")]
        RemovedFromDryingCabinetDry = 256,

        [Description("Removed from Drying Cabinet - Expired")]
        [EnumMember(Value = "RemovedFromDryingCabinetExpired")]
        RemovedFromDryingCabinetExpired = 257,

        [Description("Vacuum Packed")]
        [EnumMember(Value = "VacuumPacked")]
        VacuumPacked = 260,
        [Description("Billing Point")]
        [EnumMember(Value = "BillingPoint")]
        BillingPoint = 500,

        [Description("Print Label")]
        [EnumMember(Value = "PrintLabel")]
        PrintLabel = 560,

        [Description("Pre-AER decon task success")]
        [EnumMember(Value = "PreAerDeconTaskSuccess")]
        PreAerDeconTaskSuccess = 561,

        [Description("Pre-AER decon task failure")]
        [EnumMember(Value = "PreAerDeconTaskFailure")]
        PreAerDeconTaskFailure = 562,

        [Description("Assigned to AER")]
        [EnumMember(Value = "AssignedToAer")]
        AssignedToAer = 563,

        [Description("Removed from AER")]
        [EnumMember(Value = "RemovedFromAer")]
        RemovedFromAer = 564,

        [Description("AER start")]
        [EnumMember(Value = "AerStart")]
        AerStart = 565,

        [Description("AER passed")]
        [EnumMember(Value = "AerPassed")]
        AerPassed = 566,

        [Description("AER failed")]
        [EnumMember(Value = "AerFailed")]
        AerFailed = 567,

        [Description("Vacuum Packed - Wet")]
        [EnumMember(Value = "VacuumPackedWet")]
        VacuumPackedWet = 568,

        [Description("Vacuum Packed - Dry")]
        [EnumMember(Value = "VacuumPackedDry")]
        VacuumPackedDry = 569,

        [Description("Removed from Drying Cabinet - Automatic")]
        [EnumMember(Value = "RemovedFromDryingCabinetAutomatic")]
        RemovedFromDryingCabinetAutomatic = 570,

        [Description("Endoscopy Dispatch")]
        [EnumMember(Value = "EndoscopyDispatch")]
        EndoscopyDispatch = 595,

        #endregion

        #region Non Steam Autoclaves

        [Description("Fail Batch Pre-Non-Steam Injection")]
        [EnumMember(Value = "FailBatchPreNonSteamInjectionWithReassign")]
        FailBatchPreNonSteamInjectionWithReassign = 571,

        [Description("Fail Batch Post-Non-Steam Injection")]
        [EnumMember(Value = "FailBatchPostNonSteamInjection")]
        FailBatchPostNonSteamInjection = 572,

        [Description("Fail PreNonSteam Batch - Without Reassign")]
        [EnumMember(Value = "FailBatchPreNonSteamInjectionWithoutReassign")]
        FailBatchPreNonSteamInjectionWithoutReassign = 573,

        #endregion

        #region TrolleyDispatch
        [Description("Trolley Started")]
        [EnumMember(Value = "TrolleyStarted")]
        TrolleyStarted = 574,

        [Description("Trolley Stopped")]
        [EnumMember(Value = "TrolleyStopped")]
        TrolleyStopped = 575,

        [Description("Added To Trolley")]
        [EnumMember(Value = "AddedToTrolley")]
        AddedToTrolley = 576,

        [Description("Removed From Trolley")]
        [EnumMember(Value = "RemovedFromTrolley")]
        RemovedFromTrolley = 577,

        [Description("Trolley Dispatched")]
        [EnumMember(Value = "TrolleyDispatched")]
        TrolleyDispatched = 578,

        [Description("Turnaround can now be added to any customer trolley")]
        [EnumMember(Value = "TrolleyCustomerRestrictionDisabled")]
        TrolleyCustomerRestrictionDisabled = 579,

        [Description("Turnaround can no longer be added to any customer trolley")]
        [EnumMember(Value = "TrolleyCustomerRestrictionEnabled")]
        TrolleyCustomerRestrictionEnabled = 580,

        #endregion

        [Description("PM skipped: Customer settings")]
        [EnumMember(Value = "PmSkippedCustomerSettings")]
        PmSkippedCustomerSettings = 590,

        [Description("PM skipped: Maintenance Report Type settings")]
        [EnumMember(Value = "PmSkippedMaintenanceReportTypeSettings")]
        PmSkippedMaintenanceReportTypeSettings = 591,

        [Description("PM skipped: Container minimum capacity")]
        [EnumMember(Value = "PmSkippedContainerMinimumCapacity")]
        PmSkippedContainerMinimumCapacity = 592,

        [Description("PM skipped: Container maximum capacity")]
        [EnumMember(Value = "PmSkippedContainerMaximumCapacity")]
        PmSkippedContainerMaximumCapacity = 593,

        [Description("Unassigned from batch tag")]
        [EnumMember(Value = "UnassignedFromBatchTag")]
        UnassignedFromBatchTag = 594,

        [Description("Supervisor Approval")]
        [EnumMember(Value = "SupervisorApproval")]
        SupervisorApproval = 596,

        [Description("Autoclave Cooldown Override")]
        [EnumMember(Value = "AutoclaveCooldownOverride")]
        AutoclaveCooldownOverride = 597,

        [Description("Received For Another Loan Kit")]
        [EnumMember(Value = "ReceivedForAnotherLoanKit")]
        ReceivedForAnotherLoanKit = 598,

        #region Transit
        [Description("In Transit")]
        [EnumMember(Value = "InTransit")]
        InTransit = 700,

        [Description("Transit Cancelled")]
        [EnumMember(Value = "CancelTransit")]
        CancelTransit = 701,

        [Description("Offline - In Transit")]
        [EnumMember(Value = "OfflineTransit")]
        OfflineTransit = 702,

        [Description("Offline - Transit Cancelled")]
        [EnumMember(Value = "OfflineTransitCancelled")]
        OfflineTransitCancelled = 703,

        #endregion

    }
}