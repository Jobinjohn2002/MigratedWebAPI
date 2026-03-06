using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ItemInstanceHelpers
    {
        /// <summary>
        /// RemoveItemInstanceFromContainerInstance operation
        /// </summary>
        public static OperationResponseContract RemoveItemInstanceFromContainerInstance(ItemInstance itemInstance, ContainerInstance containerInstance, int userId, IPathwayRepository pathwayRepository, IUnitOfWork workUnit)
        {
            if (containerInstance == null)
            {
                return new OperationResponseContract(false, ContainerInstanceResources.ContainerInstanceNotFound);
            }

            if (itemInstance == null)
            {
                return new OperationResponseContract(false, ContainerInstanceResources.ItemInstanceNotFound);
            }

            itemInstance.ContainerInstance = null;
            itemInstance.Modified = DateTime.UtcNow;
            itemInstance.OwnerId = containerInstance.ContainerMasterDefinition.CustomerDefinition.CurrentCustomer.Facility.OwnerId;

            itemInstance.ItemInstanceHistory.Add(
                ItemInstanceHistoryFactory.CreateEntity(workUnit,
                    date: DateTime.UtcNow,
                    itemInstanceHistoryTypeId: (int)Enums.ItemInstanceHistoryTypeIdentifier.Disassociated,
                    userId: userId,
                    containerInstanceId: containerInstance.ContainerInstanceId
                ));

            pathwayRepository.Container.SaveChanges();

            return new OperationResponseContract(true);
        }
    }
}