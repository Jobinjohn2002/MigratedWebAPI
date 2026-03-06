using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCustomerDefectReasonHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CustomerDefectReason concreteCustomerDefectReason,
                                     CustomerDefectReason genericCustomerDefectReason)
        {
            concreteCustomerDefectReason.CustomerDefectReasonId = genericCustomerDefectReason.CustomerDefectReasonId;
            concreteCustomerDefectReason.Text = genericCustomerDefectReason.Text;
            concreteCustomerDefectReason.CausesIntoQuarantine = genericCustomerDefectReason.CausesIntoQuarantine;
            concreteCustomerDefectReason.DisplayOrder = genericCustomerDefectReason.DisplayOrder;
            concreteCustomerDefectReason.LegacyFacilityOrigin = genericCustomerDefectReason.LegacyFacilityOrigin;
            concreteCustomerDefectReason.LegacyImported = genericCustomerDefectReason.LegacyImported;
        }
    }
}