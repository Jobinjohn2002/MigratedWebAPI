using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundProcessingCycleTypesDataContract
    /// </summary>
    public class TurnaroundProcessingCycleTypesDataContract
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets BatchCycles
        /// </summary>
        public List<BatchCycleDataContract> BatchCycles { get; set; }
    }
}