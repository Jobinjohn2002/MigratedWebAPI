using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyBiologicalIndicatorTestStatusHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(BiologicalIndicatorTestStatus concreteBiologicalIndicatorTestStatus, BiologicalIndicatorTestStatus genericBiologicalIndicatorTestStatus)
        {
					
			concreteBiologicalIndicatorTestStatus.BiologicalIndicatorTestStatusId = genericBiologicalIndicatorTestStatus.BiologicalIndicatorTestStatusId;			
			concreteBiologicalIndicatorTestStatus.Text = genericBiologicalIndicatorTestStatus.Text;
		}
	}
}
		