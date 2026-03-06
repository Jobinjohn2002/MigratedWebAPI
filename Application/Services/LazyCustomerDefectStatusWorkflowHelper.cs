using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCustomerDefectStatusWorkflowHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CustomerDefectStatusWorkflow concreteCustomerDefectStatusWorkflow,
                                     CustomerDefectStatusWorkflow genericCustomerDefectStatusWorkflow)
        {
            concreteCustomerDefectStatusWorkflow.CustomerDefectStatusWorkflowId =
                genericCustomerDefectStatusWorkflow.CustomerDefectStatusWorkflowId;
            concreteCustomerDefectStatusWorkflow.FromCustomerDefectStatusId =
                genericCustomerDefectStatusWorkflow.FromCustomerDefectStatusId;
            concreteCustomerDefectStatusWorkflow.ToCustomerDefectStatusId =
                genericCustomerDefectStatusWorkflow.ToCustomerDefectStatusId;
            concreteCustomerDefectStatusWorkflow.Visible = genericCustomerDefectStatusWorkflow.Visible;
            concreteCustomerDefectStatusWorkflow.LegacyFacilityOrigin =
                genericCustomerDefectStatusWorkflow.LegacyFacilityOrigin;
            concreteCustomerDefectStatusWorkflow.LegacyImported = genericCustomerDefectStatusWorkflow.LegacyImported;
        }
    }
}