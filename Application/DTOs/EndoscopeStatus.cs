using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum EndoscopeStatus
    {
        [EnumMember]
        Inbound,

        [EnumMember]
        Decontamination,

        [EnumMember]
        AER,

        [EnumMember]
        AerPassed,

        [EnumMember]
        AerFailed,

        [EnumMember]
        RemovedFromAer,

        [EnumMember]
        DryingCabinetWet,

        [EnumMember]
        DryingCabinetDry,

        [EnumMember]
        DryingCabinetAboutToExpire,

        [EnumMember]
        DryingCabinetExpired,

        [EnumMember]
        DryingCabinetRemoved,

        [EnumMember]
        VacuumPacked,

        [EnumMember]
        VacuumPackedAboutToExpire,

        [EnumMember]
        VacuumPackedExpired,

        [EnumMember]
        VacuumPackedRemoved,

        [EnumMember]
        Quarantined,

        [EnumMember]
        Archived,

        [EnumMember]
        Unknown,

        [EnumMember]
        Dispatch
    }
}
