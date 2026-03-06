using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class PrinterData
	{
        public PrinterData()
        {

        }
		/// <summary>
		/// Gets or sets PrinterTypeName
		/// </summary>
		public string PrinterTypeName { get; set; }
	}
}