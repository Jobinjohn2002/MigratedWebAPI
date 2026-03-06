using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCustomerStatusHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CustomerStatus concreteCustomerStatus,
                                     CustomerStatus genericCustomerStatus)
        {
            concreteCustomerStatus.CustomerStatusId = genericCustomerStatus.CustomerStatusId;
            concreteCustomerStatus.Text = genericCustomerStatus.Text;
            concreteCustomerStatus.LegacyFacilityOrigin = genericCustomerStatus.LegacyFacilityOrigin;
            concreteCustomerStatus.LegacyImported = genericCustomerStatus.LegacyImported;
        }
    }
}