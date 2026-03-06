using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerInstanceLabelAuditHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerInstanceLabelAudit concreteContainerInstanceLabelAudit, ContainerInstanceLabelAudit genericContainerInstanceLabelAudit)
        {
					
			concreteContainerInstanceLabelAudit.ContainerInstanceLabelAuditId = genericContainerInstanceLabelAudit.ContainerInstanceLabelAuditId;			
			concreteContainerInstanceLabelAudit.ContainerInstanceId = genericContainerInstanceLabelAudit.ContainerInstanceId;			
			concreteContainerInstanceLabelAudit.Created = genericContainerInstanceLabelAudit.Created;			
			concreteContainerInstanceLabelAudit.CreatedUserId = genericContainerInstanceLabelAudit.CreatedUserId;			
			concreteContainerInstanceLabelAudit.StationId = genericContainerInstanceLabelAudit.StationId;			
			concreteContainerInstanceLabelAudit.FacilityId = genericContainerInstanceLabelAudit.FacilityId;			
			concreteContainerInstanceLabelAudit.OneDLabelType = genericContainerInstanceLabelAudit.OneDLabelType;
            concreteContainerInstanceLabelAudit.TwoDLabelType = genericContainerInstanceLabelAudit.TwoDLabelType;
            concreteContainerInstanceLabelAudit.LabelFormat = genericContainerInstanceLabelAudit.LabelFormat;
		}
	}
}
		