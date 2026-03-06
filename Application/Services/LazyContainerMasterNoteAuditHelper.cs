using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerMasterNoteAuditHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerMasterNoteAudit concreteContainerMasterNoteAudit, ContainerMasterNoteAudit genericContainerMasterNoteAudit)
        {
					
			concreteContainerMasterNoteAudit.ContainerMasterNoteAuditId = genericContainerMasterNoteAudit.ContainerMasterNoteAuditId;			
			concreteContainerMasterNoteAudit.ContainerMasterNoteId = genericContainerMasterNoteAudit.ContainerMasterNoteId;			
			concreteContainerMasterNoteAudit.ActiveFrom = genericContainerMasterNoteAudit.ActiveFrom;			
			concreteContainerMasterNoteAudit.CreatedByUserId = genericContainerMasterNoteAudit.CreatedByUserId;
		}
	}
}
		