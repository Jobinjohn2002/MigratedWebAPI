using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTenancyCustomValueHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TenancyCustomValue concreteTenancyCustomValue, TenancyCustomValue genericTenancyCustomValue)
        {	
			concreteTenancyCustomValue.TenancyCustomValueId = genericTenancyCustomValue.TenancyCustomValueId;			
			concreteTenancyCustomValue.TenancyId = genericTenancyCustomValue.TenancyId;			
			concreteTenancyCustomValue.RowId = genericTenancyCustomValue.RowId;			
			concreteTenancyCustomValue.Value = genericTenancyCustomValue.Value;			
			concreteTenancyCustomValue.CreatedById = genericTenancyCustomValue.CreatedById;			
			concreteTenancyCustomValue.CreatedDate = genericTenancyCustomValue.CreatedDate;			
			concreteTenancyCustomValue.ArchivedById = genericTenancyCustomValue.ArchivedById;			
			concreteTenancyCustomValue.ArchiveDate = genericTenancyCustomValue.ArchiveDate;
		}
	}
}
		