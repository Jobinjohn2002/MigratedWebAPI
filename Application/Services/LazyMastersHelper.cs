using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMastersHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Masters concreteMasters, Masters genericMasters)
        {
					
			concreteMasters.MasterType = genericMasters.MasterType;			
			concreteMasters.MasterId = genericMasters.MasterId;			
			concreteMasters.ItemId = genericMasters.ItemId;			
			concreteMasters.BaseType = genericMasters.BaseType;			
			concreteMasters.SubType = genericMasters.SubType;			
			concreteMasters.Text = genericMasters.Text;			
			concreteMasters.ItemType = genericMasters.ItemType;				
			concreteMasters.FacilityId = genericMasters.FacilityId;	
		}
	}
}
		