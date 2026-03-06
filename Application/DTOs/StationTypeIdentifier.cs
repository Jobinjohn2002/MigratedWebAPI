using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum StationTypeIdentifier
    {
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_AutoClave")]
        Autoclave = 1,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_AutoclavePassThroughDONOTUSE")]
        AutoclavePassThroughDONOTUSE = 2,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_AutoclaveDispatch")]
        AutoclaveDispatch = 3,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_AutoclaveDispatchPassThro")]
        AutoclaveDispatchPassThro = 4,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_AutoclaveOrderDispatch")]
        AutoclaveOrderDispatch = 5,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_CleanCounter")]
        CleanCounter = 6,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Default")]
        Default = 7,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_DirtyCounter")]
        DirtyCounter = 8,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Dispatch")]
        Dispatch = 9,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_DrapeInspection")]
        DrapeInspection = 10,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_DrapePacking")]
        DrapePacking = 11,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_GownPackingDouble")]
        GownPackingDouble = 12,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_GownPackingSingle")]
        GownPackingSingle = 13,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_GownPackingTriple")]
        GownPackingTriple = 14,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Inbound")]
        Inbound = 15,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_InboundWash")]
        InboundWash = 16,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Inspection")]
        Inspection = 17,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_IntoAutoclaveBatch")]
        IntoAutoclaveBatch = 18,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_IntoAutoclavePassThrough")]
        IntoAutoclavePassThrough = 19,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_IntoAutoclaveDispatchDONOTUSE")]
        IntoAutoclaveDispatchDONOTUSE = 20,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_IntoOutofAutoclave")]
        IntoOutofAutoclave = 21,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Management")]
        Management = 22,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_OutofAutoclave")]
        OutofAutoclave = 23,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Packing")]
        Packing = 24,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_QualityAssurance")]
        QualityAssurance = 25,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_QualityAssuranceAllowWorkOrders")]
        QualityAssuranceAllowWorkOrders = 26,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_StockAdministration")]
        StockAdministration = 27,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Supervisor")]
        Supervisor = 28,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_SupervisorSterileLinen")]
        SupervisorSterileLinen = 29,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Theatre")]
        Theatre = 30,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_TrayPrioritisation")]
        TrayPrioritisation = 31,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Wash")]
        Wash = 32,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_WasherReleaseDONOTUSE")]
        WasherReleaseDONOTUSE = 33,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Admin")]
        Admin = 34,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_OutofAutoclaveDispatch")]
        OutofAutoclaveDispatch = 35,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_PackingCompleted")]
        PackingCompleted = 37,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_InspectionAndAssembly")]
        InspectionAndAssembly = 38,
        [EnumMember]
        ColiseumQAStart = 39,
        [EnumMember]
        ColiseumWashStart = 40,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Orders")]
        Orders = 41,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_Coliseum")]
        Coliseum = 46,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_InspectionAndAssemblyAndQA")]
        InspectionAndAssemblyAndQA = 48,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_ClockInClockOut")]
        ClockInClockOut = 49,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_ImmediateUseSteamSterilise")]
        ImmediateUseSteamSterilise = 50,
        [EnumMember]
        [Description("Operative:Language:Operative_View_Win_Forms_Shared_DecontaminationStart")]
        Decon = 51,
        [EnumMember]
        FacilityTransfer = 52,
        [EnumMember]
        Control = 53,
        [EnumMember]
        Store = 54,
        [EnumMember]
        Weighing = 55,
        [EnumMember]
        TrayAudit = 56,
        [EnumMember]
        EpodEpoc = 57,
        [EnumMember]
        Mobile = 59,

        [EnumMember]
        EndoscopyHub = 100,
        [EnumMember]
        TrolleyDispatch = 101,
        [EnumMember]
        OOATrolleyDispatch = 110
    }
}