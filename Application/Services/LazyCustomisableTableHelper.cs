using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCustomisableTableHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CustomisableTable concreteCustomisableTable, CustomisableTable genericCustomisableTable)
        {
					
			concreteCustomisableTable.CustomisableTableId = genericCustomisableTable.CustomisableTableId;			
			concreteCustomisableTable.TableName = genericCustomisableTable.TableName;
		}
	}
}
		