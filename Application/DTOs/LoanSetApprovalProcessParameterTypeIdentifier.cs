using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum LoanSetApprovalProcessParameterTypeIdentifier
    {
        [EnumMember]
        CEMarked = 1,
        [EnumMember]
        DecontaminationCertificate = 2,
        [EnumMember]
        IsThisANewSet = 3,
        [EnumMember]
        ItemAreCompatibleWithProcess = 4,
        [EnumMember]
        IsNeutralDetergentAvailable = 5,
        [EnumMember]
        ThermalDisinfection90 = 6,
        [EnumMember]
        Sterilisation134 = 7,
        [EnumMember]
        Sterilisation121 = 8,
        [EnumMember]
        AreInstrumentsMutuallyCompatible = 9,
        [EnumMember]
        DoesDeviceThatItemContainsPhthalates = 10,
        [EnumMember]
        IsExtraTrainingRequired = 11,
    }
}
