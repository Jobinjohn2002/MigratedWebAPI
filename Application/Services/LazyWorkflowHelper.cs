using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyWorkflowHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Workflow concreteWorkflow, Workflow genericWorkflow)
        {
            concreteWorkflow.WorkflowId = genericWorkflow.WorkflowId;
            concreteWorkflow.OwnerId = genericWorkflow.OwnerId;
            concreteWorkflow.ItemTypeId = genericWorkflow.ItemTypeId;
            concreteWorkflow.FromEventTypeId = genericWorkflow.FromEventTypeId;
            concreteWorkflow.ToEventTypeId = genericWorkflow.ToEventTypeId;
            concreteWorkflow.IsEnd = genericWorkflow.IsEnd;
            concreteWorkflow.IsStockLocation = genericWorkflow.IsStockLocation;
        }
    }
}