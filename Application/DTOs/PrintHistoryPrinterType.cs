using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum PrintHistoryPrinterType
    {
        [EnumMember]
        LaserPrinter = 1,
        QALabelPrinter = 2,
        BarcodePrinter = 3
    }
}
