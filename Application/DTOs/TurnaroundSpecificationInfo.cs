using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Turnaround Specification Info.
    /// </summary>
    /// <summary>
    /// TurnaroundSpecificationInfo
    /// </summary>
    public class TurnaroundSpecificationInfo
    {
        /// <summary>
        /// The unique serial number of the turnaround, used to identify a single reprocessing cycle in the history of the asset.
        /// </summary>
        /// <summary>
        /// Gets or sets SerialNumber
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Describes the asset this turnaround specification info relates to.
        /// </summary>
        /// <summary>
        /// Gets or sets Asset
        /// </summary>
        public AssetInfo Asset { get; set; }

        /// <summary>
        /// Describes the specification of the turnaround.
        /// </summary>
        /// <summary>
        /// Gets or sets Specification
        /// </summary>
        public SpecificationInfo Specification { get; set; }

        /// <summary>
        /// Describes the exceptions for this turnaround, such as missing instruments.
        /// </summary>
        /// <summary>
        /// Gets or sets Exceptions
        /// </summary>
        public List<SpecificationExceptionInfo> Exceptions { get; set; }
        
        /// <summary>
        /// The sterile expiry date, if calculated
        /// </summary>
        public DateTime? SterileExpiryDate { get; set; }
    }
}