using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyDecontaminationTaskTimeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(DecontaminationTaskTime concreteDecontaminationTaskTime, DecontaminationTaskTime genericDecontaminationTaskTime)
        {
					
			concreteDecontaminationTaskTime.DecontaminationTaskTimeId = genericDecontaminationTaskTime.DecontaminationTaskTimeId;			
			concreteDecontaminationTaskTime.DecontaminationTaskId = genericDecontaminationTaskTime.DecontaminationTaskId;			
			concreteDecontaminationTaskTime.OwnerId = genericDecontaminationTaskTime.OwnerId;			
			concreteDecontaminationTaskTime.ProcessingTime = genericDecontaminationTaskTime.ProcessingTime;
		}
	}
}
		