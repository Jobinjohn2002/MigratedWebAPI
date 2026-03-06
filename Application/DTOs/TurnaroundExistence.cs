using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum TurnaroundExistence
    {
        [EnumMember]
        TurnaroundNotPresent = 0,
        [EnumMember]
        TurnaroundExistsInStoragePointForSameCustomer = 1,
        [EnumMember]
        TurnaroundForCustomerSelected = 2,
        [EnumMember]
        TurnaroundNotForCustomerSelected = 3,
        [EnumMember]
        TurnaroundExistsInStoragePoint = 4,
    }
}
