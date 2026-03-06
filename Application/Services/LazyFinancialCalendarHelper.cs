using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFinancialCalendarHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FinancialCalendar concreteFinancialCalendar, FinancialCalendar genericFinancialCalendar)
        {
					
			concreteFinancialCalendar.FinancialCalendarId = genericFinancialCalendar.FinancialCalendarId;			
			concreteFinancialCalendar.Year = genericFinancialCalendar.Year;			
			concreteFinancialCalendar.Period = genericFinancialCalendar.Period;			
			concreteFinancialCalendar.Week = genericFinancialCalendar.Week;			
			concreteFinancialCalendar.StartDate = genericFinancialCalendar.StartDate;			
			concreteFinancialCalendar.EndDate = genericFinancialCalendar.EndDate;
		}
	}
}
		