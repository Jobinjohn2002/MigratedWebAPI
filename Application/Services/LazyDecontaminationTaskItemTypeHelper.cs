using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyDecontaminationTaskItemTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(DecontaminationTaskItemType concreteDecontaminationTaskItemType, DecontaminationTaskItemType genericDecontaminationTaskItemType)
        {
					
			concreteDecontaminationTaskItemType.DecontaminationTaskItemTypeId = genericDecontaminationTaskItemType.DecontaminationTaskItemTypeId;			
			concreteDecontaminationTaskItemType.DecontaminationTaskId = genericDecontaminationTaskItemType.DecontaminationTaskId;			
			concreteDecontaminationTaskItemType.ItemTypeId = genericDecontaminationTaskItemType.ItemTypeId;
		}
	}
}
		