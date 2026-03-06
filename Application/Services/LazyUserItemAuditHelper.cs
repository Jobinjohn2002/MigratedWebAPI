using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyUserItemAuditHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(UserItemAudit concreteUserItemAudit, UserItemAudit genericUserItemAudit)
        {
					
			concreteUserItemAudit.UserItemAuditId = genericUserItemAudit.UserItemAuditId;			
			concreteUserItemAudit.UserId = genericUserItemAudit.UserId;			
			concreteUserItemAudit.UserItemAuditTypeId = genericUserItemAudit.UserItemAuditTypeId;			
			concreteUserItemAudit.RelatedId = genericUserItemAudit.RelatedId;			
			concreteUserItemAudit.Created = genericUserItemAudit.Created;			
			concreteUserItemAudit.Processed = genericUserItemAudit.Processed;
		}
	}
}
		