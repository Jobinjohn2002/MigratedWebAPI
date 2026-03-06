using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// PrintItem
    /// </summary>
    public class PrintItem
    {
        public string ReportPath;
        public Tuple<string, string>[] Parameters;
        public string PrinterName;
        public bool IsNetworkPrinting;
        public ScanAssetDataContract ScanDC = null;
        public int? PrintCount = 1;
        public int TurnaroundEventId;
        public bool SendToPrinter;
    }
}