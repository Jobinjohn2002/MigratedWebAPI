using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyBatchStatusHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(BatchStatus concreteBatchStatus, BatchStatus genericBatchStatus)
        {
					
			concreteBatchStatus.BatchStatusId = genericBatchStatus.BatchStatusId;			
			concreteBatchStatus.Text = genericBatchStatus.Text;
		}
	}
}
		