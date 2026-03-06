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
    public enum MaintenanceReportStatusTypeIdentifier
    {
        [EnumMember]
        Unknown = 0,

        [EnumMember]
        New = 1,

        [EnumMember]
        Quarantine = 2,

        [EnumMember]
        WithCustomer = 3,

        [EnumMember]
        WaitingQuote = 4,

        [EnumMember]
        SentForRepair = 5,

        [EnumMember]
        RepairUnsatisfactory = 6,

        [EnumMember]
        Closed = 13,

        [EnumMember]
        Cancelled = 18,

        [EnumMember]
        PlannedNewClosed = 31,

        [EnumMember]
        PlannedNewCancelled = 36
    }

    [Serializable]
    public enum MaintenanceReportRepairStatusTypeIdentifier
    {
        [EnumMember]
        Unknown = 0,

        [EnumMember]
        New = 1,

        [EnumMember]
        FaultVerification = 2,

        [EnumMember]
        SentForRepair = 3,

        [EnumMember]
        QuotationReceived = 4,

        [EnumMember]
        QuotationAuthorised = 5,

        [EnumMember]
        QuotationRejected = 6,

        [EnumMember]
        RepairReceived = 7,

        [EnumMember]
        RepairVerified = 8,

        [EnumMember]
        ReplacementRequested = 9,

        [EnumMember]
        ReplacementAuthorised = 10,

        [EnumMember]
        ReplacementRejected = 11,

        [EnumMember]
        ReplacementReceived = 12,

        [EnumMember]
        Closed = 13,

        [EnumMember]
        SentForQualityControl = 14,

        [EnumMember]
        QuotationRequested = 15,

        [EnumMember]
        Unrepairable = 16,

        [EnumMember]
        ReplacementVerified = 17,

        [EnumMember]
        Void = 18,

        [EnumMember]
        RepairCompleted = 38

    }

}