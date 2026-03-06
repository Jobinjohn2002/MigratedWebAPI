using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ConfigurableListTypeIdentifier
    {
        [EnumMember]
        [Description("Machine Type")]
        MachineType = 1,

        [EnumMember]
        [Description("Item Type")]
        ItemType = 2,

        [EnumMember]
        [Description("Decontamination Task")]
        DecontaminationTask = 3,

        [EnumMember]
        [Description("Batch Cycle")]
        BatchCycle = 4,

        [EnumMember]
        [Description("Courier")]
        Courier = 5,

        [EnumMember]
        [Description("Maintenance Activity")]
        MaintenanceActivity = 6,

        [EnumMember]
        [Description("Speciality")]
        Speciality = 7,

        [EnumMember]
        [Description("Instrument Category")]
        Category = 8,

        [EnumMember]
        [Description("Service Report Responsibility")]
        DefectResponsibility = 9,

        [EnumMember]
        [Description("Item Exception Reason")]
        ItemExceptionReason = 10,

        [EnumMember]
        [Description("Quarantine Reason")]
        QuarantineReason = 11,

        [EnumMember]
        [Description("Failure Type Event Type")]
        FailureTypeEventType = 100
    }
}
