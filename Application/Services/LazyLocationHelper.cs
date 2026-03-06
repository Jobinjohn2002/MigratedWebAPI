using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLocationHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Location concreteLocation, ILocation genericLocation)
        {					
			concreteLocation.LocationId = genericLocation.LocationId;			
			concreteLocation.LocationTypeId = genericLocation.LocationTypeId;			
			concreteLocation.Text = genericLocation.Text;
            concreteLocation.Description = genericLocation.Description;
            concreteLocation.MaximumCapacity = genericLocation.MaximumCapacity;
            concreteLocation.LeafId = genericLocation.LeafId;
            concreteLocation.Modified = genericLocation.Modified;
            concreteLocation.ModifiedUserId = genericLocation.ModifiedUserId;
            concreteLocation.LocationCode = genericLocation.LocationCode;
            concreteLocation.IsMandatoryForClockingProcess = genericLocation.IsMandatoryForClockingProcess;
            concreteLocation.IsUsagePoint = genericLocation.IsUsagePoint;
        }
    }
}
		