using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyPrinterHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Printer concretePrinter, Printer genericPrinter)
        {
            concretePrinter.PrinterId = genericPrinter.PrinterId;
            concretePrinter.ArchivedUserId = genericPrinter.ArchivedUserId;
            concretePrinter.FacilityId = genericPrinter.FacilityId;
            concretePrinter.PrinterTypeId = genericPrinter.PrinterTypeId;
            concretePrinter.Text = genericPrinter.Text;
            concretePrinter.Archived = genericPrinter.Archived;
            concretePrinter.LegacyFacilityOrigin = genericPrinter.LegacyFacilityOrigin;
            concretePrinter.LegacyImported = genericPrinter.LegacyImported;
        }
    }
}