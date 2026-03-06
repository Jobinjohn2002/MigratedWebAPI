using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerInstanceWeightHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerInstanceWeight concreteContainerInstanceWeight, ContainerInstanceWeight genericContainerInstanceWeight)
        {
					
			concreteContainerInstanceWeight.ContainerInstanceId = genericContainerInstanceWeight.ContainerInstanceId;			
			concreteContainerInstanceWeight.ApprovedPostWashWeightId = genericContainerInstanceWeight.ApprovedPostWashWeightId;			
			concreteContainerInstanceWeight.ApprovedPreWashWeightId = genericContainerInstanceWeight.ApprovedPreWashWeightId;
		    concreteContainerInstanceWeight.PostWashRefWeightKg = genericContainerInstanceWeight.PostWashRefWeightKg;
		    concreteContainerInstanceWeight.PreWashRefWeightKg = genericContainerInstanceWeight.PreWashRefWeightKg;
		    concreteContainerInstanceWeight.RequiresApproval = genericContainerInstanceWeight.RequiresApproval;
        }
	}
}
		