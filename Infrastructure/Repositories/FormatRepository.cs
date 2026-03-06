using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class FormatRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public Format Get(int formatId)
        {
            return Repository.Find(format => format.FormatId == formatId).FirstOrDefault();
        }
	}
}