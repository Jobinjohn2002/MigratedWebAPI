using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum CustomerDefectAssociationType
    {
        [EnumMember]
        ContainerInstance,

        [EnumMember]
        ContainerMaster,

        [EnumMember]
        Turnaround,

        [EnumMember]
        GeneralFault,

        [EnumMember]
        CustomerDefinition,

        [EnumMember]
        DeliveryPoint,

        [EnumMember]
        TurnaroundAutoId,

        [EnumMember]
        ContainerMasterAutoId,

        [EnumMember]
        LatestContainerMasterId,

        [EnumMember]
        ContainerInstanceAutoId,

        [EnumMember]
        Customer,
    }
}
