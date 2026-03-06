using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum OrderTypes
    {
        OrderStatusNew = 1,
        [Description("In Process")]
        [EnumMember]
        OrderStatusInProcess = 2,
        OrderStatusCompleted = 3,
        OrderStatusOnHold = 6,
        OrderStatusReadyForDispatch = 7,
        OrderStatusDispatched = 8,
        OrderStatusArchived = 4,
        OrderStatusCancelled = 5
    }
}