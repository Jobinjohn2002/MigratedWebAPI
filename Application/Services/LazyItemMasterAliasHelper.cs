using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyItemMasterAliasHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ItemMasterAlias concreteItemMasterAlias,
                                     ItemMasterAlias genericItemMasterAlias)
        {
            concreteItemMasterAlias.ItemMasterAliasId = genericItemMasterAlias.ItemMasterAliasId;
            concreteItemMasterAlias.ItemMasterDefinitionId = genericItemMasterAlias.ItemMasterDefinitionId;
            concreteItemMasterAlias.Text = genericItemMasterAlias.Text;
            concreteItemMasterAlias.Archived = genericItemMasterAlias.Archived;
            concreteItemMasterAlias.ArchivedBy = genericItemMasterAlias.ArchivedBy;
            concreteItemMasterAlias.Created = genericItemMasterAlias.Created;
            concreteItemMasterAlias.CreatedBy = genericItemMasterAlias.CreatedBy;
            concreteItemMasterAlias.ItemMasterDefinitionGroupId = genericItemMasterAlias.ItemMasterDefinitionGroupId;
            concreteItemMasterAlias.CustomerDefinitionId = genericItemMasterAlias.CustomerDefinitionId;
            concreteItemMasterAlias.CustomerGroupId = genericItemMasterAlias.CustomerGroupId;

        }
    }
}