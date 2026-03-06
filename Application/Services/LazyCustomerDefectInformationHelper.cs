using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCustomerDefectInformationHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CustomerDefectInformation concreteCustomerDefectInformation,
                                     CustomerDefectInformation genericCustomerDefectInformation)
        {
            concreteCustomerDefectInformation.CustomerDefectInformationId =
                genericCustomerDefectInformation.CustomerDefectInformationId;
            concreteCustomerDefectInformation.CreatedUserId = genericCustomerDefectInformation.CreatedUserId;
            concreteCustomerDefectInformation.CustomerDefectId = genericCustomerDefectInformation.CustomerDefectId;
            concreteCustomerDefectInformation.CustomerDefectStatusId =
                genericCustomerDefectInformation.CustomerDefectStatusId;
            concreteCustomerDefectInformation.ExternalText = genericCustomerDefectInformation.ExternalText;
            concreteCustomerDefectInformation.InternalText = genericCustomerDefectInformation.InternalText;
            concreteCustomerDefectInformation.Created = genericCustomerDefectInformation.Created;
            concreteCustomerDefectInformation.LegacyId = genericCustomerDefectInformation.LegacyId;
            concreteCustomerDefectInformation.LegacyFacilityOrigin =
                genericCustomerDefectInformation.LegacyFacilityOrigin;
            concreteCustomerDefectInformation.LegacyImported = genericCustomerDefectInformation.LegacyImported;
        }
    }
}