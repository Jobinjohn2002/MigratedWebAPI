using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyInvoiceStatusWorkflowHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(InvoiceStatusWorkflow concreteInvoiceStatusWorkflow,
                                     InvoiceStatusWorkflow genericInvoiceStatusWorkflow)
        {
            concreteInvoiceStatusWorkflow.InvoiceStatusWorkflowId = genericInvoiceStatusWorkflow.InvoiceStatusWorkflowId;
            concreteInvoiceStatusWorkflow.FromInvoiceStatusId = genericInvoiceStatusWorkflow.FromInvoiceStatusId;
            concreteInvoiceStatusWorkflow.ToInvoiceStatusId = genericInvoiceStatusWorkflow.ToInvoiceStatusId;
            concreteInvoiceStatusWorkflow.Visible = genericInvoiceStatusWorkflow.Visible;
            concreteInvoiceStatusWorkflow.LegacyFacilityOrigin = genericInvoiceStatusWorkflow.LegacyFacilityOrigin;
            concreteInvoiceStatusWorkflow.LegacyImported = genericInvoiceStatusWorkflow.LegacyImported;
        }
    }
}