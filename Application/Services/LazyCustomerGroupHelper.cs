using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCustomerGroupHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CustomerGroup concreteCustomerGroup, CustomerGroup genericCustomerGroup,bool isUpdate=false)
        {
			if (isUpdate)
			{
				concreteCustomerGroup.CustomerGroupId = genericCustomerGroup.CustomerGroupId;
			}
			else
			{
				concreteCustomerGroup.CreatedUserId = genericCustomerGroup.CreatedUserId;
				concreteCustomerGroup.Created = genericCustomerGroup.Created;
				concreteCustomerGroup.ArchivedUserId = genericCustomerGroup.ArchivedUserId;
			}
			concreteCustomerGroup.AddressId = genericCustomerGroup.AddressId;
            concreteCustomerGroup.Text = genericCustomerGroup.Text;
			concreteCustomerGroup.LegacyFacilityOrigin = genericCustomerGroup.LegacyFacilityOrigin;
			concreteCustomerGroup.LegacyImported = genericCustomerGroup.LegacyImported;
            concreteCustomerGroup.TenancyId = genericCustomerGroup.TenancyId;
            
        }
    }
}