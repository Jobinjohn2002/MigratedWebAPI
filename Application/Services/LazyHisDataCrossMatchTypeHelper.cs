using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyHisDataCrossMatchTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(HisDataCrossMatchType concreteHisDataCrossMatchType, HisDataCrossMatchType genericHisDataCrossMatchType)
        {
					
			concreteHisDataCrossMatchType.HisDataCrossMatchingTypeId = genericHisDataCrossMatchType.HisDataCrossMatchingTypeId;			
			concreteHisDataCrossMatchType.Text = genericHisDataCrossMatchType.Text;
		}
	}
}
		