using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyManufacturerHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Manufacturer concreteManufacturer, Manufacturer genericManufacturer)
        {
					
			concreteManufacturer.ManufacturerId = genericManufacturer.ManufacturerId;			
			concreteManufacturer.Name = genericManufacturer.Name;
		}
	}
}
		