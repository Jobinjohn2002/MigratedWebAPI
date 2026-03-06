using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum InspectionAssemblyProcessingMode
    {
        [EnumMember]
        Packing = 1,
        [EnumMember]
        PackingWithTrayAudit = 2,
        [EnumMember]
        StandAloneTrayAudit = 3

    }
}
