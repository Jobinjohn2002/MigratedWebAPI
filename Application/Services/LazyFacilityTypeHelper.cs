using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFacilityTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FacilityType concreteFacilityType, FacilityType genericFacilityType)
        {
					
			concreteFacilityType.FacilityTypeId = genericFacilityType.FacilityTypeId;			
			concreteFacilityType.Text = genericFacilityType.Text;
		}
	}
}
		