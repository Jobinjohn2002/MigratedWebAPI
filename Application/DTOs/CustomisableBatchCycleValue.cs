using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomisableBatchCycleValue
    /// </summary>
    public class CustomisableBatchCycleValue : CustomisableValue
    {
        /// <summary>
        /// Gets or sets IsChargeable
        /// </summary>
        public bool IsChargeable { get; set; }

        /// <summary>
        /// Gets or sets MachineTypeId
        /// </summary>
        public byte MachineTypeId { get; set; }
    }
}