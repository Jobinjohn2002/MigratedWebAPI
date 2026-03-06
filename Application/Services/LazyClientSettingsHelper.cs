using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyClientSettingsHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ClientSettings concreteClientSettings, ClientSettings genericClientSettings)
        {
					
			concreteClientSettings.Name = genericClientSettings.Name;			
			concreteClientSettings.XML = genericClientSettings.XML;		
		}
	}
}
		