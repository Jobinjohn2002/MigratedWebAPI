using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum FailureTypeIdentifier
    {
        [EnumMember(Value = "Missing Item")]
        [Description("Missing Item")]
        MissingItem = 1,

        [EnumMember(Value = "Damaged Wraps")]
        [Description("Damaged Wraps")]
        DamagedWraps = 2,

        [EnumMember(Value = "Incorrect Assembly")]
        [Description("Incorrect Assembly")]
        IncorrectAssembly = 3,

        [EnumMember(Value = "Late Supply")]
        [Description("Late Supply")]
        LateSupply = 4,

        [EnumMember(Value = "Extra Item on Tray")]
        [Description("Extra Item on Tray")]
        ExtraItemonTray = 5,

        [EnumMember(Value = "Dirty Item")]
        [Description("Dirty Item")]
        DirtyItem = 6,

        [EnumMember(Value = "Incorrect Packing Specification")]
        [Description("Incorrect Packing Specification")]
        IncorrectPackingSpecification = 7,

        [EnumMember(Value = "Other")]
        [Description("Other")]
        Other = 8,

        [EnumMember(Value = "Wrong Item on Tray")]
        [Description("Wrong Item on Tray")]
        WrongItemonTray = 9,

        [EnumMember(Value = "Wet Pack/Tray")]
        [Description("Wet Pack/Tray")]
        WetPackOrTray = 10,

        [EnumMember(Value = "Incorrect Labelling")]
        [Description("Incorrect Labelling")]
        IncorrectLabelling = 11,

        [EnumMember(Value = "Damaged Item")]
        [Description("Damaged Item")]
        DamagedItem = 12,

        [EnumMember(Value = "Worn Item")]
        [Description("Worn Item")]
        WornItem = 13,

        [EnumMember(Value = "Poststeam Failure")]
        [Description("Poststeam Failure")]
        PoststeamFailure = 14,

        [EnumMember(Value = "Presteam Failure")]
        [Description("Presteam Failure")]
        PresteamFailure = 15,

        [EnumMember(Value = "Item requires repair")]
        [Description("Item requires repair")]
        Itemrequiresrepair = 16,

        [EnumMember(Value = "Alternative Item")]
        [Description("Alternative Item")]
        AlternativeItem = 17,

        [EnumMember(Value = "Item Returned From Repair")]
        [Description("Item Returned From Repair")]
        ItemReturnedFromRepair = 18,

        [EnumMember(Value = "Item Sent To Repair")]
        [Description("Item Sent To Repair")]
        ItemSentToRepair = 19,

        [EnumMember(Value = "Gross Debris")]
        [Description("Gross Debris")]
        GrossDebris = 20,

        [EnumMember(Value = "Repatriation")]
        [Description("Repatriation")]
        Repatriation = 21,

        [EnumMember(Value = "CCN Change To Tray")]
        [Description("CCN Change To Tray")]
        CCNChangeToTray = 22,

        [EnumMember(Value = "Technician Error")]
        [Description("Technician Error")]
        TechnicianError = 23,

        [EnumMember(Value = "No Issues With Tray")]
        [Description("No Issues With Tray")]
        NoIssuesWithTray = 24,

        [EnumMember(Value = "Unknown (different technician)")]
        [Description("Unknown (different technician)")]
        UnknownDifferentTechnician = 25,

        [EnumMember(Value = "AER Disinfection Failure")]
        [Description("AER Disinfection Failure")]
        AerDisinfectionFailure = 50,

        [EnumMember(Value = "AER Test Failure")]
        [Description("AER Test Failure")]
        AerTestFailure = 51,

        [EnumMember(Value = "AER Error")]
        [Description("AER Error")]
        AerError = 52,

        [EnumMember(Value = "Blockage In Scope")]
        [Description("Blockage In Scope")]
        BlockageInScope = 53,

        [EnumMember(Value = "Leak Test")]
        [Description("Leak Test")]
        LeakTest = 54,

        [EnumMember(Value = "Out Of Detergent")]
        [Description("Out Of Detergent")]
        OutOfDetergent = 55,

        [EnumMember(Value = "Scope Connection Error")]
        [Description("Scope Connection Error")]
        ScopeConnectionError = 56,

        [EnumMember(Value = "Missing Button")]
        [Description("Missing Button")]
        MissingButton = 57,

        [EnumMember(Value = "Damaged Button")]
        [Description("Damaged Button")]
        DamagedButton = 58,

        [EnumMember(Value = "Damaged Scope")]
        [Description("Damaged Scope")]
        DamagedScope = 59,

        [EnumMember(Value = "Leak Test Failed")]
        [Description("Leak Test Failed")]
        LeakTestFailed = 60,

        [EnumMember(Value = "Unable To Clean")]
        [Description("Unable To Clean")]
        UnableToClean = 61,

        [EnumMember(Value = "Clean Failed")]
        [Description("Clean Failed")]
        CleanFailed = 62,

        [EnumMember(Value = "Post Non Steam Failure")]
        [Description("Post Non Steam Failure")]
        PostNonSteamFailure = 63,

        [EnumMember(Value = "Pre Non Steam Failure")]
        [Description("Pre Non Steam Failure")]
        PreNonSteamFailure = 64
    }
}