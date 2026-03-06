using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public enum ReportFileFormats
    {
        [EnumMember]
        PDF = 1,
        [EnumMember]
        WORD = 2,
        [EnumMember]
        IMAGE = 3,
    }
}
