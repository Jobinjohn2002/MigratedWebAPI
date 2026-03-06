using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// ServiceRequirementItemTypeRepository
    /// </summary>
    public class ServiceRequirementItemTypeRepository
    {
        /// <summary>
        /// Add operation
        /// </summary>
        public void Add(int serviceRequirementId, short itemTypeId)
        {
            using (var context = new OperativeModelContainer())
            {
                var serviceRequirement = new ServiceRequirement();
                serviceRequirement.ServiceRequirementId = serviceRequirementId;

                var itemType = new ItemType();
                itemType.ItemTypeId = itemTypeId;

                context.ServiceRequirement.Attach(serviceRequirement);
                context.ItemType.Attach(itemType);

                serviceRequirement.ItemTypes.Add(itemType);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete operation
        /// </summary>
        public void Delete(int serviceRequirementId, short itemTypeId)
        {
            {
                var serviceRequirement = new ServiceRequirement();
                serviceRequirement.ServiceRequirementId = serviceRequirementId;

                var itemType = new ItemType();
                itemType.ItemTypeId = itemTypeId;

                context.ServiceRequirement.Attach(serviceRequirement);
                context.ItemType.Attach(itemType);

                serviceRequirement.ItemTypes.Remove(itemType);

                context.SaveChanges();
            }
        }
    }
}
