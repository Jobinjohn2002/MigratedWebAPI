using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTenancyHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Tenancy concreteTenancy, Tenancy genericTenancy)
        {
					
			concreteTenancy.TenancyId = genericTenancy.TenancyId;			
			concreteTenancy.Text = genericTenancy.Text;
		}
	}
}
		