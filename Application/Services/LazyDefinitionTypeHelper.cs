using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyDefinitionTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(DefinitionType concreteDefinitionType, DefinitionType genericDefinitionType)
        {
					
			concreteDefinitionType.DefinitionTypeId = genericDefinitionType.DefinitionTypeId;			
			concreteDefinitionType.Text = genericDefinitionType.Text;
		}
	}
}
		