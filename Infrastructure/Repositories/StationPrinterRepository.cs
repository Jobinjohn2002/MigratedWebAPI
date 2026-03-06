using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class StationPrinterRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public StationPrinter Get(int id)
        {
            return Repository.Find(sp => sp.StationPrinterId == id).FirstOrDefault();
        }

        /// <summary>
        /// GetByStationAndType operation
        /// </summary>
        public StationPrinter GetByStationAndType(int stationId, int printerType)
        {
            return Repository.Find(sp => sp.StationId == stationId && sp.PrinterTypeId == printerType).FirstOrDefault();
        }

        
    }
}