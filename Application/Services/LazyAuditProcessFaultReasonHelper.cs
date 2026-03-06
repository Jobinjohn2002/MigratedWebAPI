using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyAuditProcessFaultReasonHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(AuditProcessFaultReason concreteAuditProcessFaultReason, AuditProcessFaultReason genericAuditProcessFaultReason)
        {
					
			concreteAuditProcessFaultReason.AuditProcessFaultReasonId = genericAuditProcessFaultReason.AuditProcessFaultReasonId;			
			concreteAuditProcessFaultReason.Text = genericAuditProcessFaultReason.Text;
		}
	}
}
		