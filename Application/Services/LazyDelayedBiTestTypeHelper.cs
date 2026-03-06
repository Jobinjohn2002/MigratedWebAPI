using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyDelayedBiTestTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(DelayedBiTestType concreteDelayedBiTestType, DelayedBiTestType genericDelayedBiTestType)
        {
					
			concreteDelayedBiTestType.DelayedBiTestTypeId = genericDelayedBiTestType.DelayedBiTestTypeId;			
			concreteDelayedBiTestType.Text = genericDelayedBiTestType.Text;
		}
	}
}
		