using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IInvoiceService
    /// </summary>
    public interface IInvoiceService
    {
        void GenerateInvoices(IList<int> ids, int createdUserId);
    }
}

