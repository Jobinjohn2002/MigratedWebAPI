using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLabourLevelHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LabourLevel concreteLabourLevel, LabourLevel genericLabourLevel)
        {
					
			concreteLabourLevel.LabourLevelId = genericLabourLevel.LabourLevelId;			
			concreteLabourLevel.Text = genericLabourLevel.Text;
		}
	}
}
		