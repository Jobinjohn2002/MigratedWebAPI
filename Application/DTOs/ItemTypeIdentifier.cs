using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Item Types -- Only for Item Base Type
    /// </summary>
    /// <remarks></remarks>
    [DataContract]
    public enum ItemTypeIdentifier
    {
        [EnumMember]
        Reusable = 104,
        [EnumMember]
        SingleUse = 115,
        [EnumMember]
        Tray = 140,
        [EnumMember]
        Extra = 27,
        [EnumMember]
        Supplementary = 128,
        [EnumMember]
        ProcessTag = 4009,
        [EnumMember]
        AutoclaveCassette = 4,
        [EnumMember]
        Trolley = 4010,
        [EnumMember]
        Box = 4002,
        [EnumMember]
        Drape = 22,
        [EnumMember]
        Gown = 44,
        [EnumMember]
        DrapePack = 23,
        [EnumMember]
        Container = 9,
        [EnumMember]
        GownPack = 45,
        [EnumMember]
        BatchTag = 4001,
        [EnumMember]
        OnLoanTrayTag = 98,
        [EnumMember]
        Carriage = 7,
        [EnumMember]
        Identification = 55,
        [EnumMember]
        LoanTray = 71,
        [EnumMember]
        LoanTrayLoanTray = 72,
        [EnumMember]
        NonDispatchedSoftPack = 89,
        [EnumMember]
        NonDispatchedSoftPackNoLabel = 90,
        [EnumMember]
        SoftPack = 122,
        [EnumMember]
        CassetteTag = 103,
        [EnumMember]
        BatchTagOriginal = 5,
        [EnumMember]
        BaseCarriage = 4003,
        [EnumMember]
        ChildBatchTag = 5,
        [EnumMember]
        Endoscopy = 166
    }
}