using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyInvoiceLineHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(InvoiceLine concreteInvoiceLine, InvoiceLine genericInvoiceLine)
        {
            concreteInvoiceLine.InvoiceLineId = genericInvoiceLine.InvoiceLineId;
            concreteInvoiceLine.BatchCycleId = genericInvoiceLine.BatchCycleId;
            concreteInvoiceLine.ChargeListCategoryId = genericInvoiceLine.ChargeListCategoryId;
            concreteInvoiceLine.ContainerMasterId = genericInvoiceLine.ContainerMasterId;
            concreteInvoiceLine.DeliveryPointId = genericInvoiceLine.DeliveryPointId;
            concreteInvoiceLine.InvoiceId = genericInvoiceLine.InvoiceId;
            concreteInvoiceLine.PriceCategoryId = genericInvoiceLine.PriceCategoryId;
            concreteInvoiceLine.ServiceRequirementId = genericInvoiceLine.ServiceRequirementId;
            concreteInvoiceLine.ReprocessingIndexation = genericInvoiceLine.ReprocessingIndexation;
            concreteInvoiceLine.OtherIndexation = genericInvoiceLine.OtherIndexation;
            concreteInvoiceLine.Quantity = genericInvoiceLine.Quantity;
            concreteInvoiceLine.Created = genericInvoiceLine.Created;
            concreteInvoiceLine.Removed = genericInvoiceLine.Removed;
            concreteInvoiceLine.LegacyId = genericInvoiceLine.LegacyId;
            concreteInvoiceLine.LegacyFacilityOrigin = genericInvoiceLine.LegacyFacilityOrigin;
        }
    }
}