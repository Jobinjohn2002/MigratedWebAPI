using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyAppTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(AppType concreteAppType, AppType genericAppType)
        {
					
			concreteAppType.AppTypeId = genericAppType.AppTypeId;			
			concreteAppType.Text = genericAppType.Text;
		}
	}
}
		