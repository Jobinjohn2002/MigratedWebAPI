using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyScanTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ScanType concreteScanType, ScanType genericScanType)
        {
					
			concreteScanType.ScanTypeId = genericScanType.ScanTypeId;			
			concreteScanType.Text = genericScanType.Text;
		}
	}
}
		