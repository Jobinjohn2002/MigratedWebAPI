using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ProductionEventTypeIdentifier
    {
        [EnumMember]
        AvailableForCollection = 1,

        [EnumMember]
        Collected = 2,

        [EnumMember]
        Inbound = 3,

        [EnumMember]
        Wash = 4,

        [EnumMember]
        WashReleased = 5,

        [EnumMember]
        TrayPrioritisation = 6,

        [EnumMember]
        QualityAssurance = 7,

        [EnumMember]
        IntoAutoclave = 8,

        [EnumMember]
        OutOfAutoclave = 9,

        [EnumMember]
        Dispatch = 10,

        [EnumMember]
        LoadTrolley = 11,

        [EnumMember]
        WashIn = 12,

        [EnumMember]
        InspectionAndAssembly = 13,

        [EnumMember]
        AllProductionEvents = -1,

        [EnumMember]
        MFPWash = 14,

        [EnumMember]
        MFPWashIn = 15,

        [EnumMember]
        Decontamination = 16,

        [EnumMember]
        IntoQuarantine = 17
    }
}
