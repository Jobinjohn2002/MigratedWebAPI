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
    public enum ReportFileFormatExtensions
    {
        [EnumMember]
        PDF = 1,
        [EnumMember]
        DOC = 2,
        [EnumMember]
        TIFF = 3,
    }
}