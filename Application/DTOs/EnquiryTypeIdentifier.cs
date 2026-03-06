using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{

    /// <summary>
    /// Enquire on instance or turnaround
    /// </summary>
    /// <remarks></remarks>
    public enum EnquiryTypeIdentifier
    {
        [EnumMember]
        Instance = 1,
        [EnumMember]
        Turnaround = 2,
        [EnumMember]
        Either,
    }
}
