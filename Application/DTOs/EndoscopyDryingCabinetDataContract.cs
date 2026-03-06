using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopyDryingCabinetDataContract
    /// </summary>
    public class EndoscopyDryingCabinetDataContract
    {
        /// <summary>
        /// Gets or sets Machine
        /// </summary>
        public MachineDataContract Machine { get; set; }
        /// <summary>
        /// Gets or sets ReadOnly
        /// </summary>
        public bool ReadOnly { get; set; }

        public ErrorCodes? ErrorCode { get; set; }
        
        /// <summary>
        /// Gets or sets Shelves
        /// </summary>
        public List<DryingCabinetShelfLocationDataContract> Shelves { get; set; }

    }
}
