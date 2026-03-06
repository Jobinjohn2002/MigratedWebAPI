using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DefectSeverityIdentifier
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public enum DefectSeverityIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        MinorFault = 1,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        ModerateFault = 2,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        OperationPostponed = 3,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        MajorFault = 4,
    }
}
