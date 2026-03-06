using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum PriorityViewTypeIdentifier
    {
        Standard = 1,
        ByTurnaround = 2,
        FacilityTransfer = 3,
        OrderManagement = 4,
        Shipping = 5,
        BatchPriority = 6,
        BiologicalIndicator = 7,
    }
}
