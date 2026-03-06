using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum FDAPinRequestReasonIdentifier
    {
        [EnumMember]
        [Description("Responsibility (Generic)")]
        ResponsibilityGeneric = 1,

        [EnumMember]
        [Description("Responsibility (Wash)")]
        ResponsibilityWash = 2,

        [EnumMember]
        [Description("Responsibility (Wash Release)")]
        ResponsibilityWashRelease = 3,

        [EnumMember]
        [Description("Responsibility (TP)")]
        ResponsibilityTP = 4,

        [EnumMember]
        [Description("Responsibility (QA)")]
        ResponsibilityQA = 5,

        [EnumMember]
        [Description("Responsibility (Into Auto)")]
        ResponsibilityIntoAuto = 6,

        [EnumMember]
        [Description("Responsibility (Out of Auto)")]
        ResponsibilityOutofAuto = 7,

        [EnumMember]
        [Description("Responsibility (Dispatch)")]
        ResponsibilityDispatch = 8,

        [EnumMember]
        [Description("Responsibility (Admin)")]
        ResponsibilityAdmin = 9,

        [EnumMember]
        [Description("Review (Generic)")]
        ReviewGeneric = 10,

        [EnumMember]
        [Description("Approval (Generic)")]
        ApprovalGeneric = 11
    }
}
