using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyItemMasterDefinitionGroupHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ItemMasterDefinitionGroup concreteItemMasterDefinitionGroup, ItemMasterDefinitionGroup genericItemMasterDefinitionGroup)
        {
					
			concreteItemMasterDefinitionGroup.ItemMasterDefinitionGroupId = genericItemMasterDefinitionGroup.ItemMasterDefinitionGroupId;			
			concreteItemMasterDefinitionGroup.Text = genericItemMasterDefinitionGroup.Text;			
			concreteItemMasterDefinitionGroup.CreatedBy = genericItemMasterDefinitionGroup.CreatedBy;			
			concreteItemMasterDefinitionGroup.Created = genericItemMasterDefinitionGroup.Created;			
			concreteItemMasterDefinitionGroup.ArchivedBy = genericItemMasterDefinitionGroup.ArchivedBy;			
			concreteItemMasterDefinitionGroup.Archived = genericItemMasterDefinitionGroup.Archived;			
		}
	}
}
		