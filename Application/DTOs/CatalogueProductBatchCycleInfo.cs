using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueProductBatchCycleInfo
    /// </summary>
    public class CatalogueProductBatchCycleInfo
    {
        /// <summary>
        /// Gets or sets BatchCycleName
        /// </summary>
        public string BatchCycleName { get; set; }
        /// <summary>
        /// Gets or sets BatchCycleId
        /// </summary>
        public int BatchCycleId { get; set; }
        /// <summary>
        /// Gets or sets MachineTypeName
        /// </summary>
        public string MachineTypeName { get; set; }
        /// <summary>
        /// Gets or sets MachineTypeId
        /// </summary>
        public int MachineTypeId { get; set; }
    }
}