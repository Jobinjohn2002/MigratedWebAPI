using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyItemInstanceIdentifierHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ItemInstanceIdentifier concreteItemInstanceIdentifier, ItemInstanceIdentifier genericItemInstanceIdentifier)
        {
					
			concreteItemInstanceIdentifier.ItemIdentifierId = genericItemInstanceIdentifier.ItemIdentifierId;			
			concreteItemInstanceIdentifier.ItemInstanceId = genericItemInstanceIdentifier.ItemInstanceId;			
			concreteItemInstanceIdentifier.ItemInstanceIdentifierTypeId = genericItemInstanceIdentifier.ItemInstanceIdentifierTypeId;
            concreteItemInstanceIdentifier.Value = genericItemInstanceIdentifier.Value;
		}
	}
}
		