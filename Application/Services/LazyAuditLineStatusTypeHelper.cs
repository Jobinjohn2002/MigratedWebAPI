using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyAuditLineStatusTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(AuditLineStatusType concreteAuditLineStatusType, AuditLineStatusType genericAuditLineStatusType)
        {
					
			concreteAuditLineStatusType.AuditLineStatusTypeId = genericAuditLineStatusType.AuditLineStatusTypeId;			
			concreteAuditLineStatusType.Text = genericAuditLineStatusType.Text;			
			concreteAuditLineStatusType.IsSystemOnly = genericAuditLineStatusType.IsSystemOnly;
		}
	}
}
		