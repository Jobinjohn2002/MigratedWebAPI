using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyUserItemAuditCopyListHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(UserItemAuditCopyList concreteUserItemAuditCopyList, UserItemAuditCopyList genericUserItemAuditCopyList)
        {
					
			concreteUserItemAuditCopyList.UserItemAuditCopyListId = genericUserItemAuditCopyList.UserItemAuditCopyListId;			
			concreteUserItemAuditCopyList.UserItemAuditId = genericUserItemAuditCopyList.UserItemAuditId;			
			concreteUserItemAuditCopyList.PreviousContainerMasterId = genericUserItemAuditCopyList.PreviousContainerMasterId;			
			concreteUserItemAuditCopyList.NewContainerMasterId = genericUserItemAuditCopyList.NewContainerMasterId;			
			concreteUserItemAuditCopyList.Created = genericUserItemAuditCopyList.Created;
		}
	}
}
		