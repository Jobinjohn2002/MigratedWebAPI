using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyStationPrinterHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(StationPrinter concreteStationPrinter,
                                     StationPrinter genericStationPrinter)
        {
            concreteStationPrinter.StationPrinterId = genericStationPrinter.StationPrinterId;
            concreteStationPrinter.StationId = genericStationPrinter.StationId;
            concreteStationPrinter.PrinterId = genericStationPrinter.PrinterId;
            concreteStationPrinter.PrinterTypeId = genericStationPrinter.PrinterTypeId;
        }
    }
}