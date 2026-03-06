using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// LocationDataContract
    /// </summary>
    public class LocationDataContract
    {
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets LocationTypeId
        /// </summary>
        public int LocationTypeId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        public int? MaximumCapacity { get; set; }
        /// <summary>
        /// Gets or sets LocationCode
        /// </summary>
        public string LocationCode { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets IsMandatoryForClockingProcess
        /// </summary>
        public bool IsMandatoryForClockingProcess { get; set; }
        /// <summary>
        /// Gets or sets Lft
        /// </summary>
        public int Lft { get; set; }
        /// <summary>
        /// Gets or sets Rgt
        /// </summary>
        public int Rgt { get; set; }
        public int? LeafId { get; set; }
        /// <summary>
        /// Gets or sets TreeText
        /// </summary>
        public string TreeText { get; set; }
        /// <summary>
        /// Gets or sets TreeId
        /// </summary>
        public int TreeId { get; set; }
        /// <summary>
        /// Gets or sets IsStockLocation
        /// </summary>
        public bool IsStockLocation { get; set; }
        /// <summary>
        /// Gets or sets IsUsagePoint
        /// </summary>
        public bool IsUsagePoint { get; set; }

    }
}