using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum MaintenanceInstrumentStatusTypeIdentifier
    {
        [EnumMember]
        [Description("None")]
        None = 0,

        [EnumMember]
        [Description("Open")]
        Open = 1,

        [EnumMember]
        [Description("Cancelled")]
        Cancelled = 2,

        [EnumMember]
        [Description("Completed")]
        Completed = 3,

        [EnumMember]
        [Description("Replaced from Stock")]
        ReplacedFromStock = 4,

        [EnumMember]
        [Description("BER")]
        BER = 5,

        [EnumMember]
        [Description("Replaced by Vendor")]
        ReplacedByVendor = 6
    }
}
