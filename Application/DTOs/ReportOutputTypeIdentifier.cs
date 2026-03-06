using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ReportOutputTypeIdentifier
    {
        [EnumMember]
        Display = 1,
        [EnumMember]
        DisplayPDF = 2,
        [EnumMember]
        PDF = 3,
        [EnumMember]
        Excel = 4,
        [EnumMember]
        Word = 5,
        [EnumMember]
        Xml = 6,
        [EnumMember]
        csv = 7,
        [EnumMember]
        mhtml = 8,
        [EnumMember]
        Tiff = 9,
        [EnumMember]
        Email = 10
    }
}
