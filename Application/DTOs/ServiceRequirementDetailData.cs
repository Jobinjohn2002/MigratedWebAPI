using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ServiceRequirementDetailData
    /// </summary>
    public class ServiceRequirementDetailData
    {

        public ServiceRequirementDetailData(int serviceRequirementId,string serviceRequirementName, int items, int itemsOverdue)
        {
            ServiceRequirementId = serviceRequirementId;
            ServiceRequirementName = serviceRequirementName;
            Items = items;
            ItemsOverdue = itemsOverdue;
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
