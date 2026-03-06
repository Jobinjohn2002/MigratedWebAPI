using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCustomerDefinitionHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CustomerDefinition concreteCustomerDefinition,
                                     CustomerDefinition genericCustomerDefinition)
        {
            concreteCustomerDefinition.CustomerDefinitionId = genericCustomerDefinition.CustomerDefinitionId;
            concreteCustomerDefinition.ArchivedUserId = genericCustomerDefinition.ArchivedUserId;
            concreteCustomerDefinition.Archived = genericCustomerDefinition.Archived;
            concreteCustomerDefinition.LegacyId = genericCustomerDefinition.LegacyId;
            concreteCustomerDefinition.LegacyFacilityOrigin = genericCustomerDefinition.LegacyFacilityOrigin;
            concreteCustomerDefinition.LegacyImported = genericCustomerDefinition.LegacyImported;
            concreteCustomerDefinition.OwnerId = genericCustomerDefinition.OwnerId;
            concreteCustomerDefinition.CustomerDefinitionTypeId = genericCustomerDefinition.CustomerDefinitionTypeId;
        }
    }
}