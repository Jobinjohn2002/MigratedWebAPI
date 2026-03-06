using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{

    /// <summary>
    /// Cycle Parameter Activity Type used in Cycle Parameter     
    /// </summary>
    public enum CycleParameterActivityTypeIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        [Description("Supervisor")]
        Supervisor = 1,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        [Description("Controller")]
        Controller = 2,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        [Description("Recorded")]
        Recorded = 3,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        [Description("Indicated")]
        Indicated = 4
    }
}
