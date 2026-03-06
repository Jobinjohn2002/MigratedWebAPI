using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyInvoiceScheduleHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(InvoiceSchedule concreteInvoiceSchedule, InvoiceSchedule genericInvoiceSchedule)
        {
					
			concreteInvoiceSchedule.InvoiceScheduleId = genericInvoiceSchedule.InvoiceScheduleId;			
			concreteInvoiceSchedule.CustomerDefinitionId = genericInvoiceSchedule.CustomerDefinitionId;			
			concreteInvoiceSchedule.CustomerGroupId = genericInvoiceSchedule.CustomerGroupId;			
			concreteInvoiceSchedule.DirectorateId = genericInvoiceSchedule.DirectorateId;			
			concreteInvoiceSchedule.InvoicePeriodId = genericInvoiceSchedule.InvoicePeriodId;			
			concreteInvoiceSchedule.Active = genericInvoiceSchedule.Active;			
			concreteInvoiceSchedule.LastInvoicedYear = genericInvoiceSchedule.LastInvoicedYear;			
			concreteInvoiceSchedule.LastInvoicedPeriod = genericInvoiceSchedule.LastInvoicedPeriod;			
			concreteInvoiceSchedule.LastInvoicedWeek = genericInvoiceSchedule.LastInvoicedWeek;
		}
	}
}
		