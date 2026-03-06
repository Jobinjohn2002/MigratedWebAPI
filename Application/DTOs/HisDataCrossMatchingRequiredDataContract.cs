using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HisDataCrossMatchRequiredDc
    /// </summary>
    public class HisDataCrossMatchRequiredDc
    {
        /// <summary>
        /// Gets or sets HisResourceCode
        /// </summary>
        public string HisResourceCode { get; set; }
        /// <summary>
        /// Gets or sets HisResourceName
        /// </summary>
        public string HisResourceName { get; set; }
        /// <summary>
        /// Gets or sets NumberOfIssues
        /// </summary>
        public int NumberOfIssues { get; set; }
        /// <summary>
        /// Gets or sets CrossMatchType
        /// </summary>
        public HisDataCrossMatchTypeIdentifier CrossMatchType { get; set; }
        /// <summary>
        /// Gets or sets Procedures
        /// </summary>
        public string Procedures { get; set; }
        /// <summary>
        /// Gets or sets Surgeons
        /// </summary>
        public string Surgeons { get; set; }
        /// <summary>
        /// Gets or sets EarliestRequiredDate
        /// </summary>
        public DateTime EarliestRequiredDate { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
    }
}

