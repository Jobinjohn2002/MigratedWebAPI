using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class DateTimeFormatRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public DateTimeFormat Get(int dateTimeFormatId)
        {
            return Repository.Find(dateTimeFormat => dateTimeFormat.DateTimeFormatId == dateTimeFormatId).FirstOrDefault();
        }
	}
}