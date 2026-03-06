using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyPrinterTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(PrinterType concretePrinterType, PrinterType genericPrinterType)
        {
            concretePrinterType.PrinterTypeId = genericPrinterType.PrinterTypeId;
            concretePrinterType.Text = genericPrinterType.Text;
            concretePrinterType.Selectable = genericPrinterType.Selectable;
            concretePrinterType.LegacyFacilityOrigin = genericPrinterType.LegacyFacilityOrigin;
            concretePrinterType.LegacyImported = genericPrinterType.LegacyImported;
        }
    }
}