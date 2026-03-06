using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTimeZoneHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TimeZone concreteTimeZone, TimeZone genericTimeZone)
        {
					
			concreteTimeZone.TimeZoneId = genericTimeZone.TimeZoneId;			
			concreteTimeZone.Text = genericTimeZone.Text;
		}
	}
}
		