using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCustomerDefinitionGS1Helper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CustomerDefinitionGS1 concreteCustomerDefinitionGS1,
                                     CustomerDefinitionGS1 genericCustomerDefinitionGS1)
        {
            concreteCustomerDefinitionGS1.CustomerDefinitionGS1Id = genericCustomerDefinitionGS1.CustomerDefinitionGS1Id;
            concreteCustomerDefinitionGS1.CustomerDefinitionId = genericCustomerDefinitionGS1.CustomerDefinitionId;
            concreteCustomerDefinitionGS1.ExternalId = genericCustomerDefinitionGS1.ExternalId;
            concreteCustomerDefinitionGS1.From = genericCustomerDefinitionGS1.From;
            concreteCustomerDefinitionGS1.To = genericCustomerDefinitionGS1.To;
            concreteCustomerDefinitionGS1.LastIdUsed = genericCustomerDefinitionGS1.LastIdUsed;
            concreteCustomerDefinitionGS1.Active = genericCustomerDefinitionGS1.Active;
        }
    }
}