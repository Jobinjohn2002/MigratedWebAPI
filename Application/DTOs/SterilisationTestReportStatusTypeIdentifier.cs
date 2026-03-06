using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum SterilisationTestReportStatusTypeIdentifier
    {
        [EnumMember]
        Unknown = 0,

        [EnumMember]
        [Description("Open")]
        Open = 1,

        [EnumMember]
        [Description("Test Completed")]
        Completed = 2,

        [EnumMember]
        [Description("Void")]
        Voided = 3,

        [EnumMember]
        [Description("Test Reviewed")]
        TestReviewed = 4
    }

}
