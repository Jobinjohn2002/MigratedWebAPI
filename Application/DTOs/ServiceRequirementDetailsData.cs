using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ServiceRequirementDetailsData
    /// </summary>
    public class ServiceRequirementDetailsData
    {

        public ServiceRequirementDetailsData(string serviceRequirementName, int items, int itemsOverdue, Guid stationId)
        {
            ServiceRequirementName = serviceRequirementName;
            Items = items;
            ItemsOverdue = itemsOverdue;
            StationId = stationId;
        }
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
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public Guid StationId { get; set; }

    }
}
