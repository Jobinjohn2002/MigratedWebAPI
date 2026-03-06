using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IComment : IEntityData
	{		
		int CommentId { get; set; }
			
		DateTime CreatedOn { get; set; }
			
		int CreatedBy { get; set; }
			
		int CommentContext { get; set; }
			
		string Text { get; set; }
	}
}