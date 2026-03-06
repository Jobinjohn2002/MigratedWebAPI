using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTaskHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Task concreteTask, Task genericTask)
        {
					
			concreteTask.TaskId = genericTask.TaskId;			
			concreteTask.CreatedUserId = genericTask.CreatedUserId;			
			concreteTask.Created = genericTask.Created;			
			concreteTask.ModifiedByUserId = genericTask.ModifiedByUserId;			
			concreteTask.ModifiedDate = genericTask.ModifiedDate;
		}
	}
}
		