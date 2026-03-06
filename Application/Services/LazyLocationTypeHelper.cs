using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLocationTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LocationType concreteLocationType, LocationType genericLocationType)
        {
					
			concreteLocationType.LocationTypeId = genericLocationType.LocationTypeId;			
			concreteLocationType.Text = genericLocationType.Text;			
			concreteLocationType.IsStock = genericLocationType.IsStock;
		}
	}
}
		