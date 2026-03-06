using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyInvoiceHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Invoice concreteInvoice, Invoice genericInvoice)
        {
            concreteInvoice.InvoiceId = genericInvoice.InvoiceId;
            concreteInvoice.CustomerDefinitionId = genericInvoice.CustomerDefinitionId;
            concreteInvoice.CustomerGroupId = genericInvoice.CustomerGroupId;
            concreteInvoice.DirectorateId = genericInvoice.DirectorateId;
            concreteInvoice.From = genericInvoice.From;
            concreteInvoice.To = genericInvoice.To;
            concreteInvoice.LegacyId = genericInvoice.LegacyId;
            concreteInvoice.LegacyFacilityOrigin = genericInvoice.LegacyFacilityOrigin;
            concreteInvoice.LegacyImported = genericInvoice.LegacyImported;
        }
    }
}