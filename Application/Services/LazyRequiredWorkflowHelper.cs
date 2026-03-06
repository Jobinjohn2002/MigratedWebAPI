using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyRequiredWorkflowHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(RequiredWorkflow concreteRequiredWorkflow,
                                     RequiredWorkflow genericRequiredWorkflow)
        {
            concreteRequiredWorkflow.RequiredWorkflowId = genericRequiredWorkflow.RequiredWorkflowId;
            concreteRequiredWorkflow.FromWorkflowId = genericRequiredWorkflow.FromWorkflowId;
            concreteRequiredWorkflow.ToWorkflowId = genericRequiredWorkflow.ToWorkflowId;
            concreteRequiredWorkflow.AutoRun = genericRequiredWorkflow.AutoRun;
            concreteRequiredWorkflow.LegacyFacilityOrigin = genericRequiredWorkflow.LegacyFacilityOrigin;
            concreteRequiredWorkflow.LegacyImported = genericRequiredWorkflow.LegacyImported;
        }
    }
}