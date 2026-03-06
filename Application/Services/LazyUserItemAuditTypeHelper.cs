using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyUserItemAuditTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(UserItemAuditType concreteUserItemAuditType, UserItemAuditType genericUserItemAuditType)
        {
					
			concreteUserItemAuditType.UserItemAuditTypeId = genericUserItemAuditType.UserItemAuditTypeId;			
			concreteUserItemAuditType.Text = genericUserItemAuditType.Text;
		}
	}
}
		