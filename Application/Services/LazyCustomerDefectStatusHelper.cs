using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCustomerDefectStatusHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CustomerDefectStatus concreteCustomerDefectStatus,
                                     CustomerDefectStatus genericCustomerDefectStatus)
        {
            concreteCustomerDefectStatus.CustomerDefectStatusId = genericCustomerDefectStatus.CustomerDefectStatusId;
            concreteCustomerDefectStatus.Text = genericCustomerDefectStatus.Text;
            concreteCustomerDefectStatus.Visible = genericCustomerDefectStatus.Visible;
            concreteCustomerDefectStatus.DisplayOrder = genericCustomerDefectStatus.DisplayOrder;
            concreteCustomerDefectStatus.LegacyFacilityOrigin = genericCustomerDefectStatus.LegacyFacilityOrigin;
            concreteCustomerDefectStatus.LegacyImported = genericCustomerDefectStatus.LegacyImported;
        }
    }
}