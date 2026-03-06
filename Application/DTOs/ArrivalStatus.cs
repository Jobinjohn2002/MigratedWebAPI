using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using SynergyApplicationFrameworkApi.Application.Services;
using System.ComponentModel;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ArrivalStatus
    {
        [DisplayColor("bg-green")]
        [TextDisplayColor("text-green")]
        [Description("Arrived")]
        [Tooltip("Tooltip_Arrived")]
        Arrived = 1,

        [DisplayColor("bg-pink")]
        [TextDisplayColor("text-pink")]
        [Description("Check Status")]
        [Tooltip("Tooltip_Check_Status")]
        CheckStatus = 2,

        [DisplayColor("bg-orange")]
        [TextDisplayColor("text-orange")]
        [Description("ETA Updated")]
        [Tooltip("Tooltip_ETA_Updated")]
        ETAUpdated = 3,

        [DisplayColor("bg-lightBlue")]
        [TextDisplayColor("text-lightBlue")]
        [Description("ETA Ready")]
        [Tooltip("Tooltip_ETA_Ready")]
        ETAReady = 4,

        [DisplayColor("bg-grey")]
        [TextDisplayColor("text-grey")]
        [Description("ETA Awaited")]
        [Tooltip("Tooltip_ETA_Awaited")]
        ETAAwaited = 5,
    }
}
