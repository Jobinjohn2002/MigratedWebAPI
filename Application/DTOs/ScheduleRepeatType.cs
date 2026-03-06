using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum ScheduleRepeatType
    {
        [EnumMember]
        Turnarounds = 1,

        [EnumMember]
        Days = 2,

        [EnumMember]
        Weeks = 3,

        [EnumMember]
        Months = 4,

        [EnumMember]
        Years = 5,
    }  
}
