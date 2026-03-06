using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProductionStation
    /// </summary>
    public class ProductionStation
    {
        public ProductionStation(int stationId,string stationName,int count)
        {
            StationId = stationId;
            StationName = stationName;
            Count = count;
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
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
    }
}
