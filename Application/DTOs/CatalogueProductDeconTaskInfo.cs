using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueProductDeconTaskInfo
    /// </summary>
    public class CatalogueProductDeconTaskInfo
    {
        /// <summary>
        /// Gets or sets DeconTaskName
        /// </summary>
        public string DeconTaskName { get; set; }
        /// <summary>
        /// Gets or sets DeconTaskId
        /// </summary>
        public int DeconTaskId { get; set; }
    }
}