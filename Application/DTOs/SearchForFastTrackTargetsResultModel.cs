using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SearchForFastTrackTargetsResultModel
    /// </summary>
    public class SearchForFastTrackTargetsResultModel
    {
        /// <summary>
        /// Gets or sets ReturnedResults
        /// </summary>
        public List<FastTrackTargetModel> ReturnedResults { get; set; } = new List<FastTrackTargetModel>();
        /// <summary>
        /// Gets or sets MoreResultsAvailable
        /// </summary>
        public bool MoreResultsAvailable { get; set; }
    }
}