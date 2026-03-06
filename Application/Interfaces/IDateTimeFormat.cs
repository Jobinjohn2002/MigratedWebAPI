using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IDateTimeFormat : IEntityData
	{		
		int DateTimeFormatId { get; set; }
			
		int ShortDateFormatId { get; set; }
			
		int LongDateFormatId { get; set; }
			
		int ShortTimeFormatId { get; set; }
			
		int LongTimeFormatId { get; set; }
	}
}