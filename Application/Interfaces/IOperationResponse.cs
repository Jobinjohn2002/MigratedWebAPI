using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IOperationResponse
    /// </summary>
    public interface IOperationResponse
    {
        bool Successful { get; set; }
        string Message { get; set; }
        IList<PrintDetailsDataContract> PrintJobs { get; set; }
    }
}