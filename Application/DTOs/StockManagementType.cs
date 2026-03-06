using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Used by Stock related view models to help with logic.
    /// </summary>
    public enum StockManagementType
    {
        /// <summary>
        /// We are handling a location scan.
        /// </summary>
        [EnumMember]
        Location = 1,

        /// <summary>
        /// We are handling a turnaround scan.
        /// </summary>
        [EnumMember]
        Turnaround = 2,

        /// <summary>
        /// We don't know what we are handling yet.
        /// </summary>
        [EnumMember]
        None = 3,

        /// <summary>
        /// We are specifically handling a scan to add a turnaround to stock.
        /// </summary>
        [EnumMember]
        AddTurnaround = 4,

        /// <summary>
        /// We are specifically handling a scan to remove a turnaround from stock.
        /// </summary>
        [EnumMember]
        RemoveTurnaround = 5
    }
}
