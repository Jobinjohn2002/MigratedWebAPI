using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class PrinterTypeData
	{
		/// <summary>
		/// Gets or sets ChildPrinterTypes
		/// </summary>
		public IList<PrinterTypeData> ChildPrinterTypes { get; set; }
	}
}
