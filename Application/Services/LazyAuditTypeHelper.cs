using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyAuditTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(AuditType concreteAuditType, AuditType genericAuditType)
        {
					
			concreteAuditType.AuditTypeId = genericAuditType.AuditTypeId;			
			concreteAuditType.Text = genericAuditType.Text;
		}
	}
}
		