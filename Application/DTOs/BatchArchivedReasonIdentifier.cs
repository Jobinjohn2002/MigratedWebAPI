using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum BatchArchivedReasonIdentifier
    {
        [EnumMember]
        Old = 1,

        [EnumMember]
        IncorrectCycleTypeSelected = 2,

        [EnumMember]
        BatchCreatedInError = 3
    }
}