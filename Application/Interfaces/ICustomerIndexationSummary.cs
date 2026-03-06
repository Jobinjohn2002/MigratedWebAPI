using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ICustomerIndexationSummary
    /// </summary>
    public interface ICustomerIndexationSummary
    {
        int IndexationCategoryId { get; set; }

        string Name { get; set; }

        decimal IndexationFactor { get; set; }
    }
}
