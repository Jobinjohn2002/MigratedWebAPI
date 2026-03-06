using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyAuditLineExceptionReasonHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(AuditLineExceptionReason concreteAuditLineExceptionReason, AuditLineExceptionReason genericAuditLineExceptionReason)
        {
					
			concreteAuditLineExceptionReason.AuditLineExceptionReasonId = genericAuditLineExceptionReason.AuditLineExceptionReasonId;			
			concreteAuditLineExceptionReason.Text = genericAuditLineExceptionReason.Text;			
			concreteAuditLineExceptionReason.IsVisible = genericAuditLineExceptionReason.IsVisible;			
			concreteAuditLineExceptionReason.IsDefault = genericAuditLineExceptionReason.IsDefault;
		}
	}
}
		