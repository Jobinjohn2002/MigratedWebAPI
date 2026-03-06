using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyDateTimeFormatHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(DateTimeFormat concreteDateTimeFormat, DateTimeFormat genericDateTimeFormat)
        {
					
			concreteDateTimeFormat.DateTimeFormatId = genericDateTimeFormat.DateTimeFormatId;			
			concreteDateTimeFormat.ShortDateFormatId = genericDateTimeFormat.ShortDateFormatId;			
			concreteDateTimeFormat.LongDateFormatId = genericDateTimeFormat.LongDateFormatId;			
			concreteDateTimeFormat.ShortTimeFormatId = genericDateTimeFormat.ShortTimeFormatId;			
			concreteDateTimeFormat.LongTimeFormatId = genericDateTimeFormat.LongTimeFormatId;
		}
	}
}
		