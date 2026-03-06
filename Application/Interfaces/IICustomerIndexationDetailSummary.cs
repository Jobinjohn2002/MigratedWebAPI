using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ICustomerIndexationDetailSummary
    /// </summary>
    public interface ICustomerIndexationDetailSummary
    {
        int Indexationid { get; set; }

        decimal IndexationFactor { get; set; }

        string Indexationtype { get; set; }

        DateTime AppliesFrom { get; set; }

        DateTime Created { get; set; }

        string CreatedBy { get; set; }

        string Notes { get; set; }
    }
}
