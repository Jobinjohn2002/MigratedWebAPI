using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyProcessParametersHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ProcessParameters concreteProcessParameters, ProcessParameters genericProcessParameters)
        {
					
			concreteProcessParameters.ProcessParametersId = genericProcessParameters.ProcessParametersId;			
			concreteProcessParameters.Text = genericProcessParameters.Text;
		}
	}
}
		