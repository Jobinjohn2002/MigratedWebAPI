using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class StationPrinterData
	{
        public StationPrinterData()
        {

        }

        public StationPrinterData(int stationId, int printerId, string printerName, byte printerTypeId)
		{

			StationId = stationId;

			PrinterId = printerId;

			PrinterName = printerName;

			PrinterTypeId = printerTypeId;
		}
		/// <summary>
		/// Gets or sets PrinterName
		/// </summary>
		public string PrinterName { get; set; }
		/// <summary>
		/// Gets or sets PrinterTypeName
		/// </summary>
		public string PrinterTypeName { get; set; }
	}
}