using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyDocumentAuditHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(DocumentAudit concreteDocumentAudit, DocumentAudit genericDocumentAudit)
        {
					
			concreteDocumentAudit.DocumentAuditId = genericDocumentAudit.DocumentAuditId;			
			concreteDocumentAudit.DocumentActivityTypeId = genericDocumentAudit.DocumentActivityTypeId;			
			concreteDocumentAudit.DocumentId = genericDocumentAudit.DocumentId;			
			concreteDocumentAudit.DocumentSourceId = genericDocumentAudit.DocumentSourceId;			
			concreteDocumentAudit.Created = genericDocumentAudit.Created;			
			concreteDocumentAudit.CreatedByUserId = genericDocumentAudit.CreatedByUserId;
		}
	}
}
		