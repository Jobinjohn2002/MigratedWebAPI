using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySurgeonHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Surgeon concreteSurgeon, Surgeon genericSurgeon)
        {
					
			concreteSurgeon.SurgeonId = genericSurgeon.SurgeonId;			
			concreteSurgeon.ExternalId = genericSurgeon.ExternalId;			
			concreteSurgeon.Reference = genericSurgeon.Reference;			
			concreteSurgeon.Name = genericSurgeon.Name;			
			concreteSurgeon.CreatedByUserId = genericSurgeon.CreatedByUserId;			
			concreteSurgeon.CreatedOn = genericSurgeon.CreatedOn;			
			concreteSurgeon.ModifiedByUserId = genericSurgeon.ModifiedByUserId;			
			concreteSurgeon.ModifiedOn = genericSurgeon.ModifiedOn;			
			concreteSurgeon.TenancyId = genericSurgeon.TenancyId;
		}
	}
}
		