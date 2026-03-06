using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyInvoiceStatusHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(InvoiceStatus concreteInvoiceStatus, InvoiceStatus genericInvoiceStatus)
        {
            concreteInvoiceStatus.InvoiceStatusId = genericInvoiceStatus.InvoiceStatusId;
            concreteInvoiceStatus.Text = genericInvoiceStatus.Text;
        }
    }
}