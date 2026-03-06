using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMultiFacilityProcessStatusHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MultiFacilityProcessStatus concreteMultiFacilityProcessStatus, MultiFacilityProcessStatus genericMultiFacilityProcessStatus)
        {
					
			concreteMultiFacilityProcessStatus.MultiFacilityProcessStatusId = genericMultiFacilityProcessStatus.MultiFacilityProcessStatusId;			
			concreteMultiFacilityProcessStatus.Text = genericMultiFacilityProcessStatus.Text;
		}
	}
}
		