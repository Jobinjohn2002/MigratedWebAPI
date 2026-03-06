using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class IdentifierConverter
    {
        /// <summary>
        /// ConvertEntitiesToDataContracts operation
        /// </summary>
        public static List<ContainerInstanceIdentifierDataContract> ConvertEntitiesToDataContracts(List<ContainerInstanceIdentifier> containerInstanceIdentifiers)
        {
            List<ContainerInstanceIdentifierDataContract> identifierDataContracts = new List<ContainerInstanceIdentifierDataContract>();
            foreach (ContainerInstanceIdentifier identifier in containerInstanceIdentifiers)
            {
                identifierDataContracts.Add(new ContainerInstanceIdentifierDataContract()
                {
                    ContainerInstanceIdentifierId = identifier.ContainerInstanceIdentifierId,
                    IsPrimary = identifier.IsPrimary,
                    Value = identifier.Value,
                    ContainerInstanceIdentifierType = new ContainerInstanceIdentifierTypeDataContract()
                    {
                        ContainerInstanceIdentifierTypeId = identifier.ContainerInstanceIdentifierType.ContainerInstanceIdentifierTypeId,
                        Text = identifier.ContainerInstanceIdentifierType.Text,
                        IsEditable = identifier.ContainerInstanceIdentifierType.IsEditable,
                        IsUnique = identifier.ContainerInstanceIdentifierType.IsUnique
                    }
                });
            }

            return identifierDataContracts;
        }
    }
}
