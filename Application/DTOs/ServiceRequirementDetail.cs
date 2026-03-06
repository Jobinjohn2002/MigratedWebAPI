using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ServiceRequirementDetail
    /// </summary>
    public class ServiceRequirementDetail
    {
        public ServiceRequirementDetail(int serviceRequirementId,string serviceRequiremtName, int itemsCount, int itemsOverdure)
        {
            ServiceRequirementId = serviceRequirementId;
            ServiceRequirementName = serviceRequiremtName;
            Items = itemsCount;
            ItemsOverdue = itemsOverdure;
        }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }

        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }

        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public int Items { get; set; }

        /// <summary>
        /// Gets or sets ItemsOverdue
        /// </summary>
        public int ItemsOverdue { get; set; }
    }
}
