using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ItemExceptionReasonIdentifier
    {
        [EnumMember]
        [Description("At Repair")]
        AtRepair = 1,
        [EnumMember]
        [Description("BER N/R")]
        BERNR = 2,
        [EnumMember]
        [Description("Not Returned to SSD")]
        NotReturnedToSSD = 3,
        [EnumMember]
        [Description("Stock On Order")]
        StockOnOrder = 4,
        [EnumMember]
        [Description("Theatres Aware (Authorised)")]
        TheatresAwareAuthorised = 5,
        [EnumMember]
        [Description("With Patient")]
        WithPatient = 6,
        [EnumMember]
        [Description("Never Been On Tray")]
        NeverBeenOnTray = 7,
        [EnumMember]
        [Description("Other")]
        Other = 8,
        [EnumMember]
        [Description("Damaged - not removed")]
        DamagedNotRemoved = 9,
        [EnumMember]
        [Description("Missing")]
        Missing = 10,
        [EnumMember]
        [Description("Not Available")]
        NotAvailable = 11,
        [EnumMember]
        [Description("Taken Off By Theatre")]
        TakenOffByTheatre = 12,
        [EnumMember]
        [Description("Packed as supplementary")]
        Packedassupplementary = 13,
        [EnumMember]
        [Description("Awaiting Replacement Item")]
        AwaitingReplacementItem = 14,
        [EnumMember]
        [Description("Found at Packing")]
        FoundatPacking = 15,
        [EnumMember]
        [Description("Alternative Item")]
        AlternativeItem = 16,
        [EnumMember]
        [Description("Returned from Repair")]
        ReturnedFromRepair = 17,
        [EnumMember]
        [Description("Damaged - removed")]
        DamagedRemoved = 18,
        [EnumMember]
        [Description("Alternative Size")]
        AlternativeSize = 19,
        [EnumMember]
        [Description("Alternative Shape")]
        AlternativeShape = 20,
        [EnumMember]
        [Description("Alternative Code")]
        AlternativeCode = 21
    }
}