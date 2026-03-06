using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
  
    /// <summary>
    /// ProductionStationDetail
    /// </summary>
    public class ProductionStationDetail
    {
        public ProductionStationDetail()
        {
        }

        public ProductionStationDetail(int stationId,string stationName, int itemsAtStation, bool isOverdue, string information, IList<IServiceRequirementDetail> serviceRequirementDetails)
        {
            StationId = stationId;
            StationName = stationName;
            ItemsAtStation = itemsAtStation;
            IsOverdue = isOverdue;
            Information = information;
            ServiceRequirements = serviceRequirementDetails;
        }
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }

        /// <summary>
        /// Gets or sets StationName
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// Gets or sets ItemsAtStation
        /// </summary>
        public int ItemsAtStation { get; set; }

        /// <summary>
        /// Gets or sets IsOverdue
        /// </summary>
        public bool IsOverdue { get; set; }

        /// <summary>
        /// Gets or sets Information
        /// </summary>
        public string Information { get; set; }

        /// <summary>
        /// Gets or sets ServiceRequirements
        /// </summary>
        public IList<IServiceRequirementDetail> ServiceRequirements { get; set; }
    }
}
