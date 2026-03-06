using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Asset Specification Info.
    /// </summary>
    /// <summary>
    /// AssetSpecificationInfo
    /// </summary>
    public class AssetSpecificationInfo
    {
        /// <summary>
        /// Describes the Asset this turnaround specification info relates to.
        /// </summary>
        /// <summary>
        /// Gets or sets Asset
        /// </summary>
        public AssetInfo Asset { get; set; }

        /// <summary>
        /// Describes the specification of the Asset.
        /// </summary>
        /// <summary>
        /// Gets or sets Specification
        /// </summary>
        public SpecificationInfo Specification { get; set; }

        /// <summary>
        /// Describes the current exceptions for this asset, such as missing instruments.
        /// </summary>
        /// <summary>
        /// Gets or sets Exceptions
        /// </summary>
        public List<SpecificationExceptionInfo> Exceptions { get; set; }
    }
}