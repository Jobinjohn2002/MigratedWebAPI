using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCustomerDefectHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CustomerDefect concreteCustomerDefect,
                                     CustomerDefect genericCustomerDefect)
        {
            concreteCustomerDefect.CustomerDefectId = genericCustomerDefect.CustomerDefectId;
            concreteCustomerDefect.CreatedUserId = genericCustomerDefect.CreatedUserId;
            concreteCustomerDefect.CustomerDefectStatusId = genericCustomerDefect.CustomerDefectStatusId;
            concreteCustomerDefect.TurnaroundId = genericCustomerDefect.TurnaroundId;
            concreteCustomerDefect.ExternalId = genericCustomerDefect.ExternalId;
            concreteCustomerDefect.Created = genericCustomerDefect.Created;
            concreteCustomerDefect.MissingInformation = genericCustomerDefect.MissingInformation;
            concreteCustomerDefect.DetailsInformation = genericCustomerDefect.DetailsInformation;
            concreteCustomerDefect.InternalDetailsInformation = genericCustomerDefect.InternalDetailsInformation;
            concreteCustomerDefect.ResponseInformation = genericCustomerDefect.ResponseInformation;
            concreteCustomerDefect.EmailCustomer = genericCustomerDefect.EmailCustomer;
            concreteCustomerDefect.RespondedDirectly = genericCustomerDefect.RespondedDirectly;
            concreteCustomerDefect.LegacyFacilityOrigin = genericCustomerDefect.LegacyFacilityOrigin;
            concreteCustomerDefect.LegacyImported = genericCustomerDefect.LegacyImported;
            concreteCustomerDefect.QuarantineAfterWash = genericCustomerDefect.QuarantineAfterWash;
            concreteCustomerDefect.FacilityId = genericCustomerDefect.FacilityId;
        }
    }
}