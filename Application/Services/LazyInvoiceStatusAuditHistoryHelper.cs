using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyInvoiceStatusAuditHistoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(InvoiceStatusAuditHistory concreteInvoiceStatusAuditHistory,
                                     InvoiceStatusAuditHistory genericInvoiceStatusAuditHistory)
        {
            concreteInvoiceStatusAuditHistory.InvoiceStatusAuditHistoryId =
                genericInvoiceStatusAuditHistory.InvoiceStatusAuditHistoryId;
            concreteInvoiceStatusAuditHistory.CreatedUserId = genericInvoiceStatusAuditHistory.CreatedUserId;
            concreteInvoiceStatusAuditHistory.InvoiceId = genericInvoiceStatusAuditHistory.InvoiceId;
            concreteInvoiceStatusAuditHistory.InvoiceStatusId = genericInvoiceStatusAuditHistory.InvoiceStatusId;
            concreteInvoiceStatusAuditHistory.Created = genericInvoiceStatusAuditHistory.Created;
        }
    }
}