using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum EpocEpodProcessingMode
    {
        [EnumMember]
        LoadTrolley = 1,
        [EnumMember]
        AvailableForCollection = 2,
        [EnumMember]
        Collection = 3,
        [EnumMember]
        Delivery = 4,
        [EnumMember]
        Stock = 5
    }
}
