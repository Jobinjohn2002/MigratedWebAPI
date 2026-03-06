using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ProductionStationDetailData
    /// </summary>
    public class ProductionStationDetailData
    {
        public ProductionStationDetailData(int stationId, string stationName, int itemsAtStation, bool isOverdue, string information)
        {
            StationId = stationId;
            StationName = stationName;
            ItemsAtStation = itemsAtStation;
            IsOverdue = isOverdue;
            Information = information;

        }

        public ProductionStationDetailData(int stationId,string stationName, int itemsAtStation, bool isOverdue, string information, List<ServiceRequirementDetailData> serviceRequirementDetails):this(stationId, stationName, itemsAtStation, isOverdue, information)
        {
            ServiceRequirementDetails = serviceRequirementDetails;

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
       /// Gets or sets ServiceRequirementDetails
       /// </summary>
       public IList<ServiceRequirementDetailData> ServiceRequirementDetails { get; set; }

    }
}
