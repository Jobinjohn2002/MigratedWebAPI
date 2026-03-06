using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyItemInstanceHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ItemInstance concreteItemInstance, ItemInstance genericItemInstance)
        {
            concreteItemInstance.ItemInstanceId = genericItemInstance.ItemInstanceId;
            concreteItemInstance.ContainerInstanceId = genericItemInstance.ContainerInstanceId;
            concreteItemInstance.ArchivedItemInstanceHistoryId = genericItemInstance.ArchivedItemInstanceHistoryId;
            concreteItemInstance.CreatedItemInstanceHistoryId = genericItemInstance.CreatedItemInstanceHistoryId;
        }               
    }
}