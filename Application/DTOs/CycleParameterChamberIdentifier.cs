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
    /// Cycle Parameter Chamber used in Cycle Parameter     
    /// </summary>
    public enum CycleParameterChamberIdentifier
    { /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        [Description("Sterilisation")]
        Sterilisation = 1,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        [Description("Pre Wash Rinse")]
        PreWashRinse = 2,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        [Description("Wash and Thermal Disinfection")]
        WashAndThermalDisinfection = 3,

    }
}
