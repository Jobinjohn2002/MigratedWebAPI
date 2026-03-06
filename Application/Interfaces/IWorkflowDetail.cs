using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IWorkflowDetail
    /// </summary>
    public interface IWorkflowDetail
    {
        bool IsEnd { get; set; }
        int? FromEventTypeId { get; set; }
        int NextEventTypeId { get; set; }
        int NextEventTypeCategoryId { get; set; }
        int WorkflowId { get; set; }
    }
}
