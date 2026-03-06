using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyInvoicePeriodHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(InvoicePeriod concreteInvoicePeriod, InvoicePeriod genericInvoicePeriod)
        {
					
			concreteInvoicePeriod.InvoicePeriodId = genericInvoicePeriod.InvoicePeriodId;			
			concreteInvoicePeriod.Text = genericInvoicePeriod.Text;
		}
	}
}
		