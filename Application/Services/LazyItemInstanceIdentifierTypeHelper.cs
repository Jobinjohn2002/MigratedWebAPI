using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyItemInstanceIdentifierTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ItemInstanceIdentifierType concreteItemInstanceIdentifierType, ItemInstanceIdentifierType genericItemInstanceIdentifierType)
        {
					
			concreteItemInstanceIdentifierType.ItemInstanceIdentifierTypeId = genericItemInstanceIdentifierType.ItemInstanceIdentifierTypeId;			
			concreteItemInstanceIdentifierType.Text = genericItemInstanceIdentifierType.Text;
		}
	}
}
		