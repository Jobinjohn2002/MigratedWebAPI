using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyDecontaminationTaskHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(DecontaminationTask concreteDecontaminationTask, DecontaminationTask genericDecontaminationTask)
        {
					
			concreteDecontaminationTask.DecontaminationTaskId = genericDecontaminationTask.DecontaminationTaskId;			
			concreteDecontaminationTask.TaskId = genericDecontaminationTask.TaskId;			
			concreteDecontaminationTask.Text = genericDecontaminationTask.Text;			
		}
	}
}
		