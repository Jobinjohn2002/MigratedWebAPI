using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyAuditResultTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(AuditResultType concreteAuditResultType, AuditResultType genericAuditResultType)
        {
					
			concreteAuditResultType.AuditResultTypeId = genericAuditResultType.AuditResultTypeId;			
			concreteAuditResultType.Text = genericAuditResultType.Text;
		}
	}
}
		