using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyProcessingModeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ProcessingMode concreteProcessingMode, ProcessingMode genericProcessingMode)
        {
					
			concreteProcessingMode.ProcessingModeId = genericProcessingMode.ProcessingModeId;			
			concreteProcessingMode.Text = genericProcessingMode.Text;
		}
	}
}
		