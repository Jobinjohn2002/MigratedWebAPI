using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum DeniedTurnaroundEventReasonIdentifier
    {
        [EnumMember]
        InvalidNextEvent = 1,
        [EnumMember]
        IndependantQaCheckRequired = 2,
        [EnumMember]
        FailedComplexityCheck = 3,
        [EnumMember]
        FailedSpecialityCheck = 4,
        [EnumMember]
        MachineStillRunning = 5,
        [EnumMember]
        BatchRequiresStart = 6,
        [EnumMember]
        CustomerOnStop = 7,
        [EnumMember]
        NonStockIntoStock = 8,
        [EnumMember]
        MachineTypeMismatch = 9,
        [EnumMember]
        TrolleyAwaitingDelivery = 10,
        [EnumMember]
        InvalidTrolleyMachine = 11,
        [EnumMember]
        InvalidFacility = 12,
        [EnumMember]
        NoTurnaroundWhData = 13,
        [EnumMember]
        InsufficientAuditPermissions = 14,
        [EnumMember]
        CantProcessParent = 15

    }
}
