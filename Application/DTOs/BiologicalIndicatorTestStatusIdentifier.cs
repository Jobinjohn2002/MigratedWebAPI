using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Biological Indicator Test Status used in Biological Indicator Test report 
    /// for identifying of the status of test
    /// </summary>
    public enum BiologicalIndicatorTestStatusIdentifier
    {
        [EnumMember]
        Open = 1,

        [EnumMember]
        TestCompleted = 2,

        [EnumMember]
        TestReviewed = 3,

        [EnumMember]
        InProgress = 4,

        [EnumMember]
        ReadyToComplete = 5,

        [EnumMember]
        Archived = 6,
    }
}
