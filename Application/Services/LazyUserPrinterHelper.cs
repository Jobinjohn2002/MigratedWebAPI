using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyUserPrinterHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(UserPrinter concreteUserPrinter, UserPrinter genericUserPrinter)
        {
            concreteUserPrinter.UserPrinterId = genericUserPrinter.UserPrinterId;
            concreteUserPrinter.UserId = genericUserPrinter.UserId;
            concreteUserPrinter.PrinterId = genericUserPrinter.PrinterId;
            concreteUserPrinter.LegacyFacilityOrigin = genericUserPrinter.LegacyFacilityOrigin;
            concreteUserPrinter.LegacyImported = genericUserPrinter.LegacyImported;
        }
    }
}