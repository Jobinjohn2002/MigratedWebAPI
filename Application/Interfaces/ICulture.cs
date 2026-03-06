using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ICulture : IEntityData
	{		
		int CultureId { get; set; }
			
		string Text { get; set; }
			
		string Code { get; set; }
	}
}